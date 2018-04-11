using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class ExistRequest
    {
        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("MessageReturn")]
        public string Message { get; set; }

        [JsonProperty("ListLote")]
        public int? ListLot { get; set; }
    }
}
