using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class UpdateCatalog
    {
        public UpdateCatalog()
        {
            ListProducts = new List<UpdateCatalogList>();
        }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("MessageReturn")]
        public string Message { get; set; }

        [JsonProperty("Products")]
        public List<UpdateCatalogList> ListProducts { get; set; }
    }
}
