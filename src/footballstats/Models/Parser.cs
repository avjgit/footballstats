﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Models
{
    public class Parser
    {
        public static TimeSpan GetTime(string timeRecord)
        {
            var time = timeRecord.Split(':');
            int hours = 0;
            int minutes = int.Parse(time[0]);
            int seconds = int.Parse(time[1]);
            return new TimeSpan(hours, minutes, seconds);
        }
    }
}
