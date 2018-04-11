using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class TrackingList
    {
        [JsonProperty("Rescue")]
        public string Rescue { get; set; }

        [JsonProperty("AmountPremium")]
        public string Amount { get; set; }

        [JsonProperty("PricePremium")]
        public decimal Price { get; set; }

        [JsonProperty("DateRequest")]
        public DateTime? DateRequest { get; set; }

        [JsonProperty("DatePosting")]
        public DateTime? DatePosting { get; set; }

        [JsonProperty("DateDelivery")]
        public DateTime? DateDelivery { get; set; }

        [JsonProperty("StatusId")]
        public int? StatusId { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Note")]
        public string Note { get; set; }

        [JsonProperty("Label")]
        public string Label { get; set; }

        [JsonProperty("CodeCard")]
        public string CodeCards { get; set; }
    }
}
