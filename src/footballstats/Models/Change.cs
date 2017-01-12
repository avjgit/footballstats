﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace footballstats.Models
{
    public class ChangeRecord
    {
        public int Id { get; set; }

        [JsonProperty("Maina")]
        [JsonConverter(typeof(SingleOrArrayConverter<Change>))]
        public List<Change> Changes { get; set; }
    }

    public class Change
    {
        public int Id { get; set; }

        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr1")]
        public int PlayerOut { get; set; }

        [JsonProperty("Nr2")]
        public int PlayerIn { get; set; }

        public TimeSpan Time => Parser.GetTime(TimeRecord);
    }
}
