using Newtonsoft.Json;

namespace TrenteArpents.Models
{
    public class HeartInfo : IModel
    {
        [JsonProperty("id")]
        public int Id { get; }

        [JsonProperty("activityId")]
        public int ActivityId { get; }

        [JsonProperty("hearts")]
        public int Hearts { get; }
    }
}