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
        #region Domain
        public int Id { get; set; }

        public TimeSpan Time { get; set; }

        public Player Player { get; set; }

        public List<Player> PlayersPassed { get; set; }

        [JsonProperty("Sitiens")]
        public GoalType GoalType { get; set; }
        #endregion

        #region JSON
        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr")]
        public int PlayerNr { get; set; }

        [JsonProperty("P")]
        [JsonConverter(typeof(SingleOrArrayConverter<PlayersNr>))]
        public List<PlayersNr> Passers { get; set; }
        #endregion
    }

    public class GoalsList
    {
        public int Id { get; set; }

        [JsonProperty("VG")]
        [JsonConverter(typeof(SingleOrArrayConverter<Goal>))]
        public List<Goal> Goals { get; set; }
    }
}
