using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TauManager.Models;

namespace TauManager.ViewModels
{
    public class SyndicateMetricsViewModel
    {
        public string Tag { get; set; }
        [DisplayFormat(DataFormatString = "{0:N3}")]
        public decimal Level { get; set; }
        public int Bonds { get; set; }
        public decimal Credits { get; set; }
        public int MembersCount { get; set; }
        public DateTime RecordedAt { get; set; }
        public List<SyndicateHistory> History { get; set; }
    }
}