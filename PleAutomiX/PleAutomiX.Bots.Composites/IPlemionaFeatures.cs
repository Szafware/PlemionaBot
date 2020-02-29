using PleAutomiX.Bots.Core.Enums;
using PleAutomiX.Bots.Core.Models;
using System.Collections.Generic;

namespace PleAutomiX.Bots.Features
{
    public interface IPlemionaFeatures
    {
        void SignIn(string username, string password, int worldNumber);

        void SwitchToVillage(string villageName);

        void RecruitTroops(Troops troops);

        void RecruitKnight(string knightName);

        void ReviveKnight();

        void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions);

        Resources GetCurrentVillageResources();

        Buildings GetCurrentVillageBuildings();

        void ChangeVillageName(string villageName);

        Player GetSelfInformation();

        IEnumerable<Village> GetNerbaryVillages(int radiusFields);

        void SignOut();
    }
}