using Plemiona.Core.Enums;
using Plemiona.Core.Models.Gui;
using System.Collections.Generic;

namespace Plemiona.Core.Steps.Steps
{
    public interface IPlemionaSteps
    {
        void LoadPlemionaWebsite();

        bool IsPlayerSignedIn();
        void ClickSignOutFromAccountButton();
        void FillUserTextBox(string username);
        void FillPasswordTextBox(string password);
        void ClickSignInButton();

        void ClickWorldButton(int worldNumber);

        void ClearVillageNameTextBox();
        void FillVillageNameTextBox(string villageName);
        void ClickVillageNameChangeButton();

        bool DidDailySignInGiftWindowPopUp();
        void ClickDailySignInGiftReceiveButton();

        bool DidEventWindowPopUp();
        void ClickEventWindowCloseButton();

        void ClickVillageViewButton();

        void ClickBuildingPicture(BuildingTypes building);

        void ClickKnightRecruitmentButton();
        void ClearKnightNameTextBox();
        void FillKnightNameTextBox(string knightName);
        void ClickKnightRecruitmentConfirmationButton();
        bool CanSkipKnightRecruitment();
        void ClickKnightRecruitmentSkipButton();
        void ClickKnightRecruitmentCancellationButton();
        void ClickKnightRevivalButton();
        void ClickKnightRevivalConfirmationButton();

        void FillSpearmenCountTextBox(int count);
        void FillSwordmenCountTextBox(int count);
        void FillAxemenCountTextBox(int count);
        void FillBowmenCountTextBox(int count);
        void ClickUnsaddledTroopsRecruitmentButton();

        void FillScoutCountTextBox(int count);
        void FillLightCavalaryCountTextBox(int count);
        void FillHorseArchersCountTextBox(int count);
        void FillHeavyCavalaryCountTextBox(int count);
        void ClickSaddledTroopsRecruitmentButton();

        void FillRamsCountTextBox(int count);
        void FillCatapultesCountTextBox(int count);
        void ClickWarMachinesRecruitmentTroops();

        void FillYardSpearmenCountTextBox(int count);
        void FillYardSwordmenCountTextBox(int count);
        void FillYardAxemenCountTextBox(int count);
        void FillYardBowmenCountTextBox(int count);
        void FillYardScoutCountTextBox(int count);
        void FillYardLightCavalaryCountTextBox(int count);
        void FillYardHorseArchersCountTextBox(int count);
        void FillYardHeavyCavalaryCountTextBox(int count);
        void FillYardRamsCountTextBox(int count);
        void FillYardCatapultesCountTextBox(int count);
        void FillYardKnightsCountTextBox(int count);
        void FillYardNobelmenCountTextBox(int count);
        void FillAttackCoordinatesTextBox(int coordinateX, int coordinateY);
        void ClickSendAttackButton();
        void ClickSendHelpButton();

        int GetSelfWoodCount();
        int GetSelfClayCount();
        int GetSelfIronCount();

        int GetBuildingLevel(BuildingTypes building);

        void ClickAddBuildingToBuildQueueButton(BuildingTypes building);

        void ClickWorldMapButton();

        void ClickPlayerInformationButton();

        string GetPlayerButtonTextFromProfileButtons();
        IEnumerable<ProfileVillageRow> GetVillageRows();

        void ClickSignOutFromWorldButton();
        void ClickReturnToMainPageButton();
    }
}