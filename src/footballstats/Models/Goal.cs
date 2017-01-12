using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace footballstats.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum GoalType
    {
        [EnumMember(Value = "N")]
        Game = 'N',

        [EnumMember(Value = "J")]
        Penalty = 'J'
    }

    public class Goal
    {
        public int Id { get; set; }

        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr")]
        public int PlayerNr { get; set; }

        [JsonProperty("Sitiens")]
        public GoalType GoalType { get; set; }

        [JsonProperty("P")]
        public List<PlayersNr> Passers { get; set; }

        public TimeSpan Time => Parser.GetTime(TimeRecord);
    }
}
