using Newtonsoft.Json;
using System.Collections.Generic;

namespace TrenteArpents.Models
{
    public class Album : IModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("photos")]
        public List<Photo> Photos { get; set; }
    }
}
