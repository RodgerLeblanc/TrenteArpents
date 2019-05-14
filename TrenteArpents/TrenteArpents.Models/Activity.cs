using System;
using Newtonsoft.Json;

namespace TrenteArpents.Models
{
    public class Activity : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("time")]
        public string Time { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        [JsonProperty("isVisible")]
        public bool IsVisible { get; set; } = true;
    }
}
