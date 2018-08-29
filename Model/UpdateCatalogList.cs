using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.API.ERP.Model
{
    public class UpdateCatalogList
    {
        [JsonProperty("SKU")]
        public string SKU { get; set; }

        [JsonProperty("SKUMain")]
        public string SKUMain { get; set; }

        [JsonProperty("IsFreeRange")]
        public bool IsFreeRange { get; set; }

        [JsonProperty("IsVirtual")]
        public bool IsVirtual { get; set; }

        [JsonProperty("PriceUN")]
        public decimal PriceUN { get; set; }

        [JsonProperty("RateADM")]
        public decimal RateADM { get; set; }

        [JsonProperty("Freight")]
        public decimal Freight { get; set; }

        [JsonProperty("Handling")]
        public decimal Handling { get; set; }

        [JsonProperty("PriceTotal")]
        public decimal PriceTotal { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }

        [JsonProperty("Enable")]
        public bool Enable { get; set; }

        [JsonProperty("LinkImageSmall")]
        public string LinkImageSmall { get; set; }

        [JsonProperty("LinkImageMedium")]
        public string LinkImageMedium { get; set; }

        [JsonProperty("LinkImageLarge")]
        public string LinkImageLarge { get; set; }

        [JsonProperty("LinkImageCover")]
        public string LinkImageCover { get; set; }

        [JsonProperty("CategoryId")]
        public int CategoryId { get; set; }

        [JsonProperty("Category")]
        public string Category { get; set; }
    }
}
