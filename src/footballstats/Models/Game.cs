using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace footballstats.Models
{
    public class Record
    {
        public int Id { get; set; }

        [JsonProperty("Spele")]
        public Game Spele { get; set; }
    }

    public class Game
    {
        public int Id { get; set; }

        [JsonProperty("Laiks")]
        public DateTime Date { get; set; }

        [JsonProperty("Vieta")]
        public string Place { get; set; }

        [JsonProperty("Skatitaji")]
        public int Spectators { get; set; }

        [JsonProperty("T")]
        public List<Referee> Referees { get; set; }

        [JsonProperty("VT")]
        public Referee Referee { get; set; }
    }
}
