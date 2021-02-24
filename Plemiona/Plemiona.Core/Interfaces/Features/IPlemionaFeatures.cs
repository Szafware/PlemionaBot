using Plemiona.Core.Enums;
using Plemiona.Core.Models;
using Plemiona.Core.Models.Features;
using System.Collections.Generic;

namespace Plemiona.Core.Interfaces.Features
{
    public interface IPlemionaFeatures
    {
        void SignIn(string plemionaUrl, string username, string password, int worldNumber);

        void SwitchToVillage(string villageName);

        void RecruitKnight(string knightName);

        void ReviveKnight();

        void RecruitTroops(Troops troops);

        Troops GetTroops();

        void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions, SendingTroopsInfo sendingTroopsInfo = null);

        Resources GetResources();

        Buildings GetBuildings();

        void ChangeVillageName(string villageName);

        void AddBuildingToQueue(BuildingTypes Building);

        OwnPlayer GetOwnPlayer();

        Player GetPlayer(string playerName);

        IEnumerable<Village> GetNerbaryVillages(int radiusFields);

        Village GetVillage(int coordinateX, int coordinateY);

        void SignOut();
    }
}