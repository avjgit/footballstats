﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace footballstats.Models
{
    public class Penalty
    {
        public int Id { get; set; }

        public Player Player { get; set; }

        public TimeSpan Time { get; set; }

        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr")]
        public int PlayerNr { get; set; }
    }
    public class PenaltiesList
    {
        public int Id { get; set; }

        [JsonProperty("Sods")]
        [JsonConverter(typeof(SingleOrArrayConverter<Penalty>))]
        public List<Penalty> Penalties { get; set; }
    }

}
