using footballstats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Models
{
    public class Team
    {
        public int Id { get; set; }

        [JsonProperty("Nosaukums")]
        public string Title { get; set; }

        [JsonProperty("Speletaji")]
        public PlayersList AllPLayersRecord { get; set; }

        [JsonProperty("Pamatsastavs")]
        public PlayersNrList MainPlayersRecord { get; set; }

        [JsonProperty("Sodi")]
        public PenaltiesList PenaltiesRecord { get; set; }

        [JsonProperty("Varti")]
        public GoalsList GoalsRecord { get; set; }

        [JsonProperty("Mainas")]
        public ChangeRecord ChangeRecord { get; set; }

        // todo: add for Penalties (under Player?)
        public List<Player> AllPLayers { get; set; }

        public List<Player> MainPlayers { get; set; }
    }
}
