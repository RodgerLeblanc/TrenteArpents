using System;
using Newtonsoft.Json;

namespace TrenteArpents.Models
{
    public class Photo : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }
    }
}
