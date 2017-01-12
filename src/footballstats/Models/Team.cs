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

    public class PenaltiesList
    {
        public int Id { get; set; }

        [JsonProperty("Sods")]
        [JsonConverter(typeof(SingleOrArrayConverter<Penalty>))]
        public List<Penalty> Penalties { get; set; }
    }

    public class GoalsList
    {
        public int Id { get; set; }

        [JsonProperty("VG")]
        [JsonConverter(typeof(SingleOrArrayConverter<Goal>))]
        public List<Goal> Goals { get; set; }
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
