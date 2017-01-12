using Newtonsoft.Json;

namespace footballstats.Models
{
    public class Referee
    {
        public int Id { get; set; }

        [JsonProperty("Vards")]
        public string Firstname { get; set; }

        [JsonProperty("Uzvards")]
        public string Lastname{ get; set; }
    }
}
