using System.Threading.Tasks;
using TauManager.Models;
using TauManager.ViewModels;

namespace TauManager.BusinessLogic
{
    public interface IPlayerLogic
    {
        SyndicatePlayersViewModel GetSyndicatePlayers(int? playerId, bool includeInactive, int syndicateId);
        HomePageViewModel GetHomePageModel(int? playerId, bool isOfficer);
        Task<string> ParsePlayerPageAsync(string fileContents, int syndicateId);
        Task<bool> SetPlayerActiveAsync(int playerId, bool status);
        PlayerDetailsViewModel GetPlayerDetails(int id, bool? loadAll);
        ChartDataSet GetPlayerDetailsChartData(int id, byte interval, byte dataKind);
        SkillOverviewViewModel GetSkillsOverview(string skillGroupName, int syndicateId);
        string RequestPlayerDiscordLink(string playerName, string discordLogin);
        Task<bool> SetPlayerDiscordAccountAsync(int? playerId, string login, string authCode);
        bool SetPlayerNotificationFlags(int? playerId, int notificationFlags);
        Player GetPlayerById(int id);
        Task<bool> DisconnectDiscordAccount(int? playerId);
        bool DisconnectDiscordAccountByDiscordLogin(string discordLogin);
    }
}