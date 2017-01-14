using Newtonsoft.Json;
using System.Collections.Generic;

namespace footballstats.Models
{
    public class Team
    {
        #region Domain
        public int Id { get; set; }

        [JsonProperty("Nosaukums")]
        public string Title { get; set; }

        public List<Player> AllPLayers { get; set; }
        #endregion

        #region JSON
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
        #endregion
    }
}
