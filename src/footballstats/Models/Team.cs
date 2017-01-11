using footballstats.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace footballstats.Models
{
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

    public class Team
    {
        public int Id { get; set; }

        [JsonProperty("Nosaukums")]
        public string Title { get; set; }

        [JsonProperty("Speletaji")]
        public PlayersList AllPLayersRecord { get; set; }

        [JsonProperty("Pamatsastavs")]
        public PlayersNrList MainPlayersRecord { get; set; }
    }
}
