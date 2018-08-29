using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class Authentication
    {
        public bool Success { get; set; }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty(".expires")]
        public DateTime Expires { get; set; }

        public string Message { get; set; }

        public bool IsAuthenticated
        {
            get {
                var result = false;

                if (!string.IsNullOrEmpty(AccessToken) && Expires >= DateTime.UtcNow)
                {
                    result = true;
                }

                return result;
            }
        }
    }
}
