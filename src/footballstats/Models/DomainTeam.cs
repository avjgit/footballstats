﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Models
{
    public class DomainTeam
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int GoalsWon { get; set; }
        public int GoalsLost { get; set; }
        public int WinsDuringMainTime { get; set; }
        public int LossesDuringMainTime { get; set; }
        public int WinsDuringAddedTime { get; set; }
        public int LossesDuringAddedTime { get; set; }
        public int Points { get; set; }
        public int Place { get; set; }
        public int PenaltyGoals { get; set; }
        public int Defendors { get; set; }
        public int Forwards { get; set; }
        public int Goalkeepers { get; set; }
        public TimeSpan TotalTimePlayed { get; set; }
        public TimeSpan AverageTimePlayed { get; set; }
    }
}
