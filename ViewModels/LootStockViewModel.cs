using System.Collections.Generic;
using TauManager.Models;

namespace TauManager.ViewModels
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class LootStockViewModel
    {
        public IDictionary<int, IEnumerable<CampaignLoot>> AllLootByTier { get; set; }
        public Dictionary<int, string> LootStatuses { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}