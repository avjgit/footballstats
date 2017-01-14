using Newtonsoft.Json;
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
        #region Domain
        public int Id { get; set; }

        public Player PlayerIn_ { get; set; }

        public Player PlayerOut_ { get; set; }

        public TimeSpan Time { get; set; }
        #endregion

        #region JSON fields
        [JsonProperty("Laiks")]
        public string TimeRecord { get; set; }

        [JsonProperty("Nr1")]
        public int PlayerOut { get; set; }

        [JsonProperty("Nr2")]
        public int PlayerIn { get; set; }
        #endregion
    }
}
