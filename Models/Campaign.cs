using System.Linq;
using System;
using System.ComponentModel;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TauManager.Models
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class CampaignDiff{
        public Dictionary<string, string> Changes { get; set; }
        [JsonIgnore]
        public bool StatusChangeOnly => Changes.Count == 1 && Changes.ContainsKey(Campaign.FieldNames.Status);
        [JsonIgnore]
        public bool TimeChange => Changes.ContainsKey(Campaign.FieldNames.UTCDateTime);
        [JsonIgnore]
        public bool PlaceChange => Changes.ContainsKey(Campaign.FieldNames.Station);
        [JsonIgnore]
        public bool NoChanges => Changes.Count == 0;
        public void AddChange(string key, object oldValue, object newValue)
        {
            Changes[key] = string.Format("{0} => {1}", oldValue, newValue);
        }
    }

    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class Campaign
    {
        public static class FieldNames
        {
            public static string Station => "Station";
            public static string UTCDateTime => "UTCDateTime";
            public static string Difficulty => "Difficulty";
            public static string Status => "Status";
            public static string Manager => "Manager";
            public static string Tiers => "Tiers";
            public static string Comments => "Comments";
            public static string Name => "Name";
            public static string ExcludeFromLeaderboards => "ExcludeFromLeaderboards";
        }
        public enum CampaignStatus : byte { Unknown, Assigned, Planned, InProgress, Abandoned, Completed, Failed, Skipped };
        public enum CampaignDifficulty : byte { Easy, Normal, Hard, Extreme };
        public int Id { get; set; }
        public string Name { get; set; }
        public int? SyndicateId { get; set; }
        public virtual Syndicate Syndicate { get; set; }
        public DateTime? UTCDateTime { get; set; }
        public string UTCDateString
        {
            get
            {
                return UTCDateTime.HasValue ? UTCDateTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : "Not set";
            }
        } 
        public string GCTDateString
        {
            get
            {
                return UTCDateTime.HasValue ? Utils.GCT.MakeGCTDateTime(UTCDateTime.Value) : "Not set";
            }
        }
        public int? ManagerId { get; set; }
        public virtual Player Manager { get; set; }
        [DefaultValue(CampaignStatus.Unknown)]
        public CampaignStatus Status { get; set; }
        public string Station { get; set; }
        public CampaignDifficulty? Difficulty { get; set; }
        public int? Tiers { get; set; }
        public string TiersString 
        { 
            get
            {
                if (!Tiers.HasValue)
                {
                    return "Not set";
                }
                return String.Join(',', TiersList.Select(t => t.ToString()));
            } 
        }
        public List<int> TiersList 
        { 
            get
            {
                var result = new List<int>();
                if (Tiers.HasValue)
                {
                    var tiers_temp = Tiers.Value;
                    for (var tier = 5; tier > 0; tier--)
                    {
                        if (tiers_temp >= Math.Pow(2, tier-1))
                        {
                            result.Insert(0, tier);
                            tiers_temp -= (int)Math.Round(Math.Pow(2, tier-1));
                        }
                    }
                }
                return result;
            }
        }
        public string Comments { get; set; }
        [DefaultValue(false)]
        public bool ExcludeFromLeaderboards { get; set; }
        public virtual IEnumerable<CampaignSignup> Signups { get; set; }
        public Dictionary<int, int> SignupsDict 
        {
             get
             {
                 if (Signups == null) return new Dictionary<int, int>();
                 return Signups.ToDictionary(s => s.PlayerId, s => 1);
             }
        }
        public virtual IEnumerable<CampaignAttendance> Attendance { get; set; }
        public Dictionary<int, int> AttendanceDict 
        {
             get
             {
                 if (Attendance == null) return new Dictionary<int, int>();
                 return Attendance.ToDictionary(s => s.PlayerId, s => 1);
             }
        }
        public virtual IEnumerable<CampaignLoot> Loot { get; set; }

        public CampaignDiff Diff(Campaign newValues)
        {
            var result = new CampaignDiff {
                Changes = new Dictionary<string, string>(),
            };
            if (newValues.Difficulty != Difficulty)
            {
                result.AddChange(Campaign.FieldNames.Difficulty, Difficulty, newValues.Difficulty);
            }
            if (newValues.Station != Station)
            {
                result.AddChange(Campaign.FieldNames.Station, Station, newValues.Station);
            }
            if (newValues.Status != Status)
            {
                result.AddChange(Campaign.FieldNames.Status, Status, newValues.Status);
            }
            if (newValues.Tiers != Tiers)
            {
                result.AddChange(Campaign.FieldNames.Tiers, TiersString, newValues.TiersString);
            }
            if (newValues.UTCDateTime != UTCDateTime)
            {
                result.AddChange(Campaign.FieldNames.UTCDateTime, UTCDateString, newValues.UTCDateString);
            }
            if (newValues.Comments != Comments)
            {
                result.AddChange(Campaign.FieldNames.Comments, Comments, newValues.Comments);
            }
            if (newValues.ExcludeFromLeaderboards != ExcludeFromLeaderboards)
            {
                result.AddChange(Campaign.FieldNames.ExcludeFromLeaderboards, ExcludeFromLeaderboards, newValues.ExcludeFromLeaderboards);
            }
            if (newValues.ManagerId != ManagerId)
            {
                result.AddChange(Campaign.FieldNames.Manager, Manager == null ? "<undefined>" : Manager.Name, newValues.Manager == null ? "<undefined>" : newValues.Manager.Name);
            }
            return result;
        }
    }
}