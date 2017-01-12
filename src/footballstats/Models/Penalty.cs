using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Models
{
    public class Penalty
    {
        public int Id { get; set; }

        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr")]
        public int PlayerNr { get; set; }

        public TimeSpan Time => Parser.GetTime(TimeRecord);
    }
    public class PenaltiesList
    {
        public int Id { get; set; }

        [JsonProperty("Sods")]
        [JsonConverter(typeof(SingleOrArrayConverter<Penalty>))]
        public List<Penalty> Penalties { get; set; }
    }

}
