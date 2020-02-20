using PleAutomiX.Bots.Core.Enums;
using PleAutomiX.Bots.Core.Models;
using PleAutomiX.Bots.Steps.StepTypes.Specific;

namespace PleAutomiX.Bots.Composites
{
    public class PlemionaComposites : IPlemionaComposites
    {
        private readonly IPlemionaSpecificSteps _plemionaSpecificSteps;

        public PlemionaComposites(IPlemionaSpecificSteps plemionaSpecificSteps)
        {
            _plemionaSpecificSteps = plemionaSpecificSteps;
        }

        public void SignIn(string username, string password, int worldNumber)
        {
            _plemionaSpecificSteps.LoadPlemionaWebsite();
            _plemionaSpecificSteps.FillUserTextBox(username);
            _plemionaSpecificSteps.FillPasswordTextBox(password);
            _plemionaSpecificSteps.ClickSignInButton();
            _plemionaSpecificSteps.ClickWorldButton(worldNumber);
        }

        public void RecruitTroops(Troops troops)
        {
            if (troops.AreUnsaddledTroopsPresent)
            {
                _plemionaSpecificSteps.ClickVillageViewButton();
                _plemionaSpecificSteps.ClickBarracksPicture();
                _plemionaSpecificSteps.FillSpearmenCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillSwordmenCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillAxemenCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillBowmenCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.ClickUnsaddledTroopsRecruitmentButton();
            }

            if (troops.AreSaddledTroopsPresent)
            {
                _plemionaSpecificSteps.ClickVillageViewButton();
                _plemionaSpecificSteps.ClickStablePicture();
                _plemionaSpecificSteps.FillScoutCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillLightCavalaryCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillHorseArchersCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillHeavyCavalaryCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.ClickSaddledTroopsRecruitmentButton();
            }

            if (troops.AreWarMachinesTroopsPresent)
            {
                _plemionaSpecificSteps.ClickVillageViewButton();
                _plemionaSpecificSteps.ClickWorkshopPicture();
                _plemionaSpecificSteps.FillRamsCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.FillCatapultesCountTextBox(troops.Spearmen);
                _plemionaSpecificSteps.ClickWarMachinesRecruitmentTroops();
            }

            if (troops.Noblemen > 0)
            {
                _plemionaSpecificSteps.ClickPalacePicture();
                // TODO - Monety? Nie monety?

                _plemionaSpecificSteps.ClickVillageViewButton();
            }

            _plemionaSpecificSteps.ClickVillageViewButton();
        }

        public void RecruitKnight()
        {
            _plemionaSpecificSteps.ClickStatuePicture();
            _plemionaSpecificSteps.ClickKnightRecruitmentButton();
            _plemionaSpecificSteps.ClickVillageViewButton();

        }

        public void ReviveKnight()
        {
            _plemionaSpecificSteps.ClickStatuePicture();
            _plemionaSpecificSteps.ClickKnightRevivalButton();
            _plemionaSpecificSteps.ClickVillageViewButton();

        }

        public void SendAttack(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions)
        {
            _plemionaSpecificSteps.ClickYardPicture();

            _plemionaSpecificSteps.FillYardSpearmenCountTextBox(troops.Spearmen);
            _plemionaSpecificSteps.FillYardSwordmenCountTextBox(troops.Swordmen);
            _plemionaSpecificSteps.FillYardAxemenCountTextBox(troops.Axemen);
            _plemionaSpecificSteps.FillYardBowmenCountTextBox(troops.Bowmen);

            _plemionaSpecificSteps.FillYardScoutCountTextBox(troops.Scouts);
            _plemionaSpecificSteps.FillYardLightCavalaryCountTextBox(troops.LightCavalary);
            _plemionaSpecificSteps.FillYardHorseArchersCountTextBox(troops.HorseArchers);
            _plemionaSpecificSteps.FillHeavyCavalaryCountTextBox(troops.HeavyCavalary);
            
            _plemionaSpecificSteps.FillYardRamsCountTextBox(troops.Rams);
            _plemionaSpecificSteps.FillYardCatapultesCountTextBox(troops.Catapultes);

            _plemionaSpecificSteps.FillYardKnightsCountTextBox(troops.Knights);
            _plemionaSpecificSteps.FillYardNobelmenCountTextBox(troops.Noblemen);

            _plemionaSpecificSteps.FillAttackCoordinatesTextBox(coordinateX, coordinateY);

            if (troopsIntentions == TroopsIntentions.Attack)
            {
                _plemionaSpecificSteps.ClickSendAttackButton();
            }
            else
            {
                _plemionaSpecificSteps.ClickSendHelpButton();
            }

            _plemionaSpecificSteps.ClickVillageViewButton();
        }
    }
}