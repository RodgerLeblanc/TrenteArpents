using System;
using Newtonsoft.Json;

namespace TrenteArpents.Models
{
    public class Activity : IModel
    {
        private const string timeFormat = "h:mm tt";

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("timeStart")]
        public DateTimeOffset TimeStart { get; set; }

        [JsonProperty("timeEnd")]
        public DateTimeOffset TimeEnd { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        public string Time { get => $"{TimeStart.ToString(timeFormat)} - {TimeEnd.ToString(timeFormat)}"; }
    }
}
