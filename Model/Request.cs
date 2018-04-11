using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class Request
    {
        [JsonProperty("CodRequest")]
        public string CodRequest { get; set; }

        [JsonProperty("SKU")]
        public string SKU { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CPF_CNPJ")]
        public string Document { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Address")]
        public string AddressStreet { get; set; }

        [JsonProperty("AddressNumber")]
        public string AddressNumber { get; set; }

        [JsonProperty("AddressComplement")]
        public string AddressComplement { get; set; }

        [JsonProperty("District")]
        public string AddressDistrict { get; set; }

        [JsonProperty("City")]
        public string AddressCity { get; set; }

        [JsonProperty("State")]
        public string AddressState { get; set; }

        [JsonProperty("CEP")]
        public string AddressZipCode { get; set; }

        [JsonProperty("PhoneContact")]
        public string Phone { get; set; }

        [JsonProperty("AmountPremium")]
        public int Amount { get; set; } = 1;

        [JsonProperty("PricePremium")]
        public decimal? PricePremium { get; set; } = 0;

        [JsonProperty("PayBillBarcode")]
        public string PayBillBarcode { get; set; }

        [JsonProperty("PayBillValue")]
        public decimal? PayBillValue { get; set; }

        [JsonProperty("CodeCard")]
        public string CodeCard { get; set; }
    }
}
