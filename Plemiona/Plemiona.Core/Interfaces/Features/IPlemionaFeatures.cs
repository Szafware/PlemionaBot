using Plemiona.Core.Enums;
using Plemiona.Core.Models;
using System.Collections.Generic;

namespace Plemiona.Core.Interfaces.Features
{
    public interface IPlemionaFeatures
    {
        void SignIn(string username, string password, int worldNumber);

        void SwitchToVillage(string villageName);

        void RecruitTroops(Troops troops);

        void RecruitKnight(string knightName);

        void ReviveKnight();

        void SendTroops(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions);

        Resources GetResources();

        Buildings GetBuildings();

        void ChangeVillageName(string villageName);

        void AddBuildingToQueue(BuildingTypes Building);

        Player GetSelfInformation();

        IEnumerable<Village> GetNerbaryVillages(int radiusFields);

        void SignOut();
    }
}