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
        public SyndicateLogic(TauDbContext dbContext)
        {
            _dbContext = dbContext;
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
    }
}