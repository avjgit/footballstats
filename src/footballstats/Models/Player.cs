﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace footballstats.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum PlayerRole
    {
        [EnumMember(Value = "V")]
        Goalkeeper = 'V',

        [EnumMember(Value = "A")]
        Defender = 'A',

        [EnumMember(Value = "U")]
        Forward = 'U'
    }

    public class PlayersNr
    {
        public int Id { get; set; }
        public int Nr { get; set; }
    }

    public class Player
    {
        public int Id { get; set; }

        [JsonProperty("Vards")]
        public string Firstname { get; set; }

        [JsonProperty("Uzvards")]
        public string Lastname { get; set; }

        [JsonProperty("Nr")]
        public int Number { get; set; }

        [JsonProperty("Loma")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PlayerRole Role { get; set; }

        public string Team { get; set; }

        public int Goals { get; set; }

        public int Passes { get; set; }
    }

    public class PlayersList
    {
        public int Id { get; set; }

        [JsonProperty("Speletajs")]
        public List<Player> Players { get; set; }
    }

    public class PlayersNrList
    {
        public int Id { get; set; }

        [JsonProperty("Speletajs")]
        public List<PlayersNr> PlayersNrs { get; set; }
    }
}
