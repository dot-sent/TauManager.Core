using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using TauManager.Models;
using System.Threading.Tasks;
using TauManager.ViewModels;
using System;

namespace TauManager.BusinessLogic
{
    public class SyndicateLogic : ISyndicateLogic
    {
        private TauDbContext _dbContext { get; set; }
        private IPlayerLogic _playerLogic { get; set; }
        public SyndicateLogic(TauDbContext dbContext, IPlayerLogic playerLogic)
        {
            _dbContext = dbContext;
            _playerLogic = playerLogic;
        }

        public Syndicate GetSyndicateByPlayerId(int playerId)
        {
            var player = _dbContext.Player.SingleOrDefault(p => p.Id == playerId);
               if (player == null) return null;
            return player.Syndicate;
        }

        public Syndicate GetSyndicateById(int id)
        {
            return _dbContext.Syndicate.SingleOrDefault(s => s.Id == id);
        }

        public SyndicateListViewModel GetAllSyndicates(ClaimsPrincipal currentUser, int? userPlayerId, int? userSyndicate)
        {
            var result = _dbContext.Syndicate.ToDictionary(s => s.Id, s => s.Tag);

            var userPlayer = _dbContext.Player.SingleOrDefault(p => p.Id == userPlayerId);

            return new SyndicateListViewModel{
                AllSyndicates = result,
                CurrentOverride = userSyndicate.HasValue ? 
                    new KeyValuePair<int, string>(userSyndicate.Value, result[userSyndicate.Value]) :
                    new KeyValuePair<int, string>(0, "default"),
                DefaultSyndicate = userPlayer == null || userPlayer.Syndicate == null ?
                    new KeyValuePair<int, string>(0, "not set") :
                    new KeyValuePair<int, string>(userPlayer.SyndicateId.Value, userPlayer.Syndicate.Tag),
            };
        }

        public SyndicatePlayerViewModel GetSyndicatePlayerAssignment()
        {
            var result = new SyndicatePlayerViewModel();

            result.AllSyndicates = _dbContext.Syndicate.AsEnumerable();
            result.SyndicatePlayers = _dbContext.Player
                .AsEnumerable()
                .GroupBy(p => p.SyndicateId)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key.HasValue ? g.Key.Value : 0,
                    g => g.OrderBy(p => p.Name).AsEnumerable()
                );
            return result;
        }

        public async Task<bool> SetPlayerSyndicate(int playerId, int? syndicateId)
        {
            var player = _dbContext.Player.SingleOrDefault(p => p.Id == playerId);
            if (player == null) return false;
            var syndicate = _dbContext.Syndicate.SingleOrDefault(s => s.Id == syndicateId);
            if (syndicateId.HasValue && syndicate == null) return false;

            player.SyndicateId = syndicateId;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public Player GetPlayerById(int? id)
        {
            return id.HasValue ? _dbContext.Player.SingleOrDefault(p => p.Id == id.Value) : null;
        }

        public async Task<bool> SubmitSyndicateHistory(SyndicateInfoViewModel entry)
        {
            var syndicate = _dbContext.Syndicate.SingleOrDefault(s => s.Tag == entry.Tag);
            if (syndicate == null) return false;
            var historyEntry = new SyndicateHistory(entry);
            historyEntry.RecordedAt = DateTime.Now;
            historyEntry.SyndicateId = syndicate.Id;
            _dbContext.Add(historyEntry);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public SyndicateStatsViewModel GetSyndicateInfo(int syndicateId)
        {
            var syndicate = _dbContext.Syndicate.SingleOrDefault(s => s.Id == syndicateId);
            if (syndicate == null) return null;
            var syndicateHistories = syndicate.History.ToList();
            var lastMetrics = syndicateHistories.OrderByDescending(sh => sh.RecordedAt).FirstOrDefault();
            if (lastMetrics == null) return null;
            var playerStats = _playerLogic.GetSyndicatePlayers(0, false, syndicateId);
            var response = new SyndicateStatsViewModel{
                Bonds = lastMetrics.Bonds,
                Credits = lastMetrics.Credits,
                Level = lastMetrics.Level,
                MembersCount = lastMetrics.MembersCount,
                RecordedAt = lastMetrics.RecordedAt,
                Tag = syndicate.Tag,
                History = syndicateHistories,
                PlayerStats = playerStats,
            };

            return response;
        }

        public ChartDataSet GetSyndicateHistoricalData(int syndicateId, byte interval, byte dataKind)
        {
            var result = new ChartDataSet();
            var syndicate = _dbContext.Syndicate.SingleOrDefault(s => s.Id == syndicateId);
            if (syndicate == null) return result;
            var startDate = ChartDataSet.GetStartDate(interval);
            if (startDate == null) return result;
            var relevantData = _dbContext.SyndicateHistory.Where(sh => sh.SyndicateId == syndicateId && sh.RecordedAt >= startDate)
                .OrderBy(sh => sh.RecordedAt)
                .AsEnumerable() // Flesh out the data before client-side grouping
                .GroupBy(sh => sh.RecordedAt.Date)
                .Select(g =>
                    new {
                        RecordedAt = g.Key,
                        HistoryEntry = g.OrderByDescending(sh => sh.RecordedAt).First()
                    }
                );
            switch (dataKind)
            {
                case (byte)ChartDataSet.DataKind.MemberCount:
                    result.AddRange(
                        relevantData.Select(he => new ChartDataPoint { t = he.RecordedAt, y = (double)he.HistoryEntry.MembersCount })
                    );
                    break;
                case (byte)ChartDataSet.DataKind.Credits:
                    result.AddRange(
                        relevantData.Select(he => new ChartDataPoint { t = he.RecordedAt, y = (double)he.HistoryEntry.Credits })
                    );
                    break;
                case (byte)ChartDataSet.DataKind.Bonds:
                    result.AddRange(
                        relevantData.Select(he => new ChartDataPoint { t = he.RecordedAt, y = (double)he.HistoryEntry.Bonds })
                    );
                    break;
                case (byte)ChartDataSet.DataKind.XP:
                    result.AddRange(
                        relevantData.Select(he => new ChartDataPoint { t = he.RecordedAt, y = (double)he.HistoryEntry.Level })
                    );
                    break;
                default: // This means invalid input data
                    return result;
            }

            return result;
        }
    }
}