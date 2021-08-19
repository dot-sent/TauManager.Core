using System.Collections.Generic;

namespace TauManager.Utils
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class TauTrackerItem
    {
        public string rarity { get; set; }
        public string image { get; set; }
        public decimal value { get; set; }
        public string slug { get; set; }
        public string type { get; set; }

        #region Weapon block
        public bool? hand_to_hand { get; set; }
        public string weapon_type { get; set; }
        public decimal? piercing_damage { get; set; }
        public decimal? impact_damage { get; set; }
        public decimal? energy_damage { get; set; }
        public decimal? accuracy { get; set; }
        public string weapon_range { get; set; }
        #endregion

        #region Armor block
        public decimal? piercing_defense { get; set; }
        public decimal? impact_defense { get; set; }
        public decimal? energy_defense { get; set; }
        #endregion
        public decimal mass_kg { get; set; }
        public int tier { get; set; }
        public string name { get; set; }
    }
}