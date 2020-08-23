using System.Security.Claims;
using TauManager.Models;
using System.Threading.Tasks;
using TauManager.ViewModels;

namespace TauManager.BusinessLogic
{
    public interface ISyndicateLogic
    {
        Syndicate GetSyndicateByPlayerId(int playerId);
        Syndicate GetSyndicateById(int id);
        SyndicateListViewModel GetAllSyndicates(ClaimsPrincipal currentUser, int? playerId, int? syndicateOverride);
        SyndicatePlayerViewModel GetSyndicatePlayerAssignment();
        Task<bool> SetPlayerSyndicate(int playerId, int? syndicateId);
        Task<bool> SubmitSyndicateHistory(SyndicateInfoViewModel historyEntry);
        SyndicateStatsViewModel GetSyndicateInfo(int syndicateId);
        ChartDataSet GetSyndicateHistoricalData(int syndicateId, byte interval, byte dataKind);
    }
}