using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class Tracking
    {
        public Tracking()
        {
            ListLot = new List<TrackingList>();
        }

        [JsonProperty("Success")]
        public bool Success { get; set; }

        [JsonProperty("MessageReturn")]
        public string Message { get; set; }

        [JsonProperty("ListLote")]
        public List<TrackingList> ListLot { get; set; }
    }
}
