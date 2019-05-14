using Newtonsoft.Json;
using System;
using System.Drawing;

namespace TrenteArpents.Models
{
    public partial class Sponsor : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("sponsorType")]
        public long SponsorType { get; set; }

        [JsonProperty("promoUrl")]
        public Uri PromoUrl { get; set; }

        [JsonProperty("backgroundColor")]
        public string BackgroundColor { get; set; } = "#00000000";

        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; } = true;
    }
}

