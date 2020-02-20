namespace PleAutomiX.Bots.Steps.StepTypes.Specific
{
    public interface IPlemionaSpecificSteps
    {
        void LoadPlemionaWebsite();

        void FillUserTextBox(string username);
        void FillPasswordTextBox(string password);
        void ClickSignInButton();

        void ClickWorldButton(int worldNumber);

        void ClickDailySignInGiftReceiveButton();

        void ClickVillageViewButton();

        void ClickTownhallPicture();
        void ClickYardPicture();
        void ClickBarracksPicture();
        void ClickStatuePicture();
        void ClickStablePicture();
        void ClickWorkshopPicture();
        void ClickPalacePicture();

        void ClickKnightRevivalButton();
        void ClickKnightRecruitmentButton();

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

        void ClickToWorldMapButton();
    }
}