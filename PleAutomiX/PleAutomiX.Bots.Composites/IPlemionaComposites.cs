using PleAutomiX.Bots.Core.Enums;
using PleAutomiX.Bots.Core.Models;
using PleAutomiX.Game.Attributes;
using PleAutomiX.Translation.Attributes;
using PleAutomiX.Translation.Constants;
using PleAutomiX.Translation.Enums;

namespace PleAutomiX.Bots.Composites
{
    public interface IPlemionaComposites
    {
        [ActionDescription(Languages.POLISH, "Zaloguj")]
        [ActionDescription(Languages.ENGLISH, "Sign in")]
        void SignIn(
            [ParameterDescription(Languages.POLISH, "Nazwa użytkownika", ParameterTypes.String)]
            [ParameterDescription(Languages.ENGLISH, "Nick", ParameterTypes.String)]
            string username,

            [ParameterDescription(Languages.POLISH, "Hasło", ParameterTypes.String)]
            [ParameterDescription(Languages.ENGLISH, "Password", ParameterTypes.String)]
            string password,

            [ParameterDescription(Languages.POLISH, "Numer świata", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "World number", ParameterTypes.Int)]
            int worldNumber);

        void RecruitTroops(Troops troops);

        public void RecruitKnight();

        public void ReviveKnight();

        void SendAttack(Troops troops, int coordinateX, int coordinateY, TroopsIntentions troopsIntentions);
    }
}