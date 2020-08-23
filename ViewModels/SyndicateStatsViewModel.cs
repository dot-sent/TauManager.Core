using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TauManager.Models;

namespace TauManager.ViewModels
{
    public class SyndicateStatsViewModel
    {
        public string Tag { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Level { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Bonds { get; set; }
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public decimal Credits { get; set; }
        public int MembersCount { get; set; }
        [DisplayFormat(DataFormatString = "{0:u}")]
        public DateTime RecordedAt { get; set; }

        public List<SyndicateHistory> History { get; set; }
        public SyndicatePlayersViewModel PlayerStats { get; set; }
    }
}