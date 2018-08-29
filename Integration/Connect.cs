using Newtonsoft.Json;
using Serilog;
using Service.API.ERP.Common;
using Service.API.ERP.Interface;
using Service.API.ERP.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Service.API.ERP.Integration
{
    public class Connect : IConnect
    {
        private IConfig _config;

        private HttpClient _client;

        public Connect(IConfig config)
        {
            _config = config;

            _client = new HttpClient();
            _client.BaseAddress = new Uri(_config.GetUrl());
            _client.DefaultRequestHeaders.Clear();

            Log.Information("ERP - Inicializar - {Link}", _config.GetUrl());
        }

        private async Task<Authentication> GetOauth()
        {
            var result = new Authentication();
            var payload = new Dictionary<string, string>
            {
                { "grant_type", "password" },
                { "username",  _config.GetUserName() },
                { "password",  _config.GetPassword() }
            };

            var content = new FormUrlEncodedContent(payload);
            var response = await _client.PostAsync("oauth/token", content);

            result.Success = response.IsSuccessStatusCode;

            if (response.IsSuccessStatusCode)
            {
                var information = response.Content.ReadAsStringAsync().Result;
                result = JsonConvert.DeserializeObject<Authentication>(information);
                Log.Information("ERP - Autenticação - Realizado - Expira: {Expires}", result.Expires);
            }
            else
            {
                result.Message = response.RequestMessage.ToString();
                Log.Error("ERP - Autenticação - Error: {Message}", result.Message);
            }

            return result;
        }

        public async Task<ExistRequest> GetExistRescue(long rescue)
        {
            var result = new ExistRequest();

            var sign = await GetOauth();

            if (sign.IsAuthenticated)
            {
                var url = string.Format("api/v3/existrequest?Token={0}&CodRequest={1}", _config.GetToken(), rescue.ToString());
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sign.AccessToken); 

                var response = await _client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<ExistRequest>(information);
                }
                else
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result.Message = response.RequestMessage.ToString();
                }
            }

            return result;
        }

        public async Task<RequestReturn> AddRequest(Request request)
        {
            var result = new RequestReturn();

            var sign = await GetOauth();

            if (sign.IsAuthenticated)
            {
                var payload = new Dictionary<string, string>
                {
                    { "Token", _config.GetToken() },
                    { "CodRequest",  request.CodRequest },
                    { "SKU",  request.SKU },
                    { "Name",  request.Name },
                    { "CPF_CNPJ",  request.Document },
                    { "Email",  request.Email },
                    { "Address",  request.AddressStreet },
                    { "AddressNumber",  request.AddressNumber },
                    { "AddressComplement",  request.AddressComplement },
                    { "District",  request.AddressDistrict },
                    { "City",  request.AddressCity },
                    { "State",  request.AddressState },
                    { "CEP",  request.AddressZipCode },
                    { "PhoneContact",  request.Phone },
                    { "DateRegister",  string.Format("{0:yyyy-MM-dd}",DateTime.Now) },
                    { "AmountPremium",  request.Amount.ToString() },
                    { "PricePremium",   request.PricePremium.GetPriceWithCommand() },
                    { "PayBillBarcode",  request.PayBillBarcode },
                    { "PayBillValue",   request.PayBillValue.GetPriceWithCommand()},
                    { "CodeCard",  request.CodeCard }
                };

                var content = new FormUrlEncodedContent(payload);

                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sign.AccessToken);
                var response = await _client.PostAsync("api/v3/addresquest", content);

                result.Success = response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RequestReturn>(information);
                }
                else
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<RequestReturn>(information);
                    Log.Error("ERP - Adicionar resgate - Error: {Message}", result.Message);
                }
            }

            return result;
        }

        public async Task<Tracking> GetTracking(long rescue)
        {
            var result = new Tracking();

            var sign = await GetOauth();

            if (sign.IsAuthenticated)
            {
                var url = string.Format("api/v3/findtracking?Token={0}&CodRequest={1}", _config.GetToken(), rescue.ToString());
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sign.AccessToken);

                var response = await _client.GetAsync(url);

                result.Success = response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<Tracking>(information);
                }
                else
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result.Message = response.RequestMessage.ToString();
                    Log.Error("ERP - Buscar tracking - Error: {Message}", result.Message);
                }
            }

            return result;
        }

        public async Task<UpdateCatalog> GetCatalog()
        {
            var result = new UpdateCatalog();

            var sign = await GetOauth();

            if (sign.IsAuthenticated)
            {
                var url = string.Format("api/v3/products?Token={0}", _config.GetToken());
                _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sign.AccessToken);

                var response = await _client.GetAsync(url);

                result.Success = response.IsSuccessStatusCode;

                if (response.IsSuccessStatusCode)
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result = JsonConvert.DeserializeObject<UpdateCatalog>(information, new JsonSerializerSettings
                    {
                        Culture = new CultureInfo("pt-BR")
                    });
                }
                else
                {
                    var information = response.Content.ReadAsStringAsync().Result;
                    result.Message = response.RequestMessage.ToString();
                    Log.Error("ERP - Buscar catálogo - Error: {Message}", result.Message);
                }
            }

            return result;
        }

        public void Dispose()
        {
            _config.Dispose();
            _client.Dispose();
        }
    }
}
