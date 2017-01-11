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

        public int Nr { get; set; }

        public TimeSpan Time
        {
            get
            {
                var time = TimeRecord.Split(':');
                return new TimeSpan(
                    hours: 0, 
                    minutes: int.Parse(time[0]), 
                    seconds: int.Parse(time[1]));
            }
        }
    }
}
