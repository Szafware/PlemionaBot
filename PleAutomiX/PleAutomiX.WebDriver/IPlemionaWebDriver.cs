using PleAutomiX.Game.Attributes;
using PleAutomiX.Translation.Attributes;
using PleAutomiX.Translation.Constants;
using PleAutomiX.Translation.Enums;

namespace PleAutomiX.Bots.WebDriver
{
    public interface IPlemionaWebDriver
    {
        [ActionDescription(Languages.POLISH, "Załaduj stronę Plemion")]
        [ActionDescription(Languages.ENGLISH, "Load Plemiona website")]
        void LoadPlemionaWebsite();

        [ActionDescription(Languages.POLISH, "Zaloguj")]
        [ActionDescription(Languages.ENGLISH, "Sign in")]
        void SignIn(
            [ParameterDescription(Languages.POLISH, "Nazwa użytkownika", ParameterTypes.String)]
            [ParameterDescription(Languages.ENGLISH, "Nick", ParameterTypes.String)]
            string username,

            [ParameterDescription(Languages.POLISH, "Hasło", ParameterTypes.String)]
            [ParameterDescription(Languages.ENGLISH, "Password", ParameterTypes.String)]
            string password);

        [ActionDescription(Languages.POLISH, "Wybierz świat")]
        [ActionDescription(Languages.ENGLISH, "Pick a world")]
        void PickWorld(
            [ParameterDescription(Languages.POLISH, "Numer świata", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "World number", ParameterTypes.Int)]
            int worldNumber);

        [ActionDescription(Languages.POLISH, "Odbierz bonus dziennego logowania")]
        [ActionDescription(Languages.ENGLISH, "Get everyday sign in gift")]
        void GetDailySignInGift();

        [ActionDescription(Languages.POLISH, "Przejdź do podglądu wioski")]
        [ActionDescription(Languages.ENGLISH, "Go to village overview")]
        void GoToVillageView();

        [ActionDescription(Languages.POLISH, "Przejdź do - Ratusz")]
        [ActionDescription(Languages.ENGLISH, "Go to - Townhall")]
        void GoToTownhall();

        [ActionDescription(Languages.POLISH, "Przejdź do - Koszary")]
        [ActionDescription(Languages.ENGLISH, "Go to - Barracks")]
        void GoToBarracks();

        [ActionDescription(Languages.POLISH, "Rekrutuj pikinierów")]
        [ActionDescription(Languages.ENGLISH, "Recruit spearmen")]
        void RecruitSpearmen(
            [ParameterDescription(Languages.POLISH, "Ilość", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "Count", ParameterTypes.Int)]
            int count);

        [ActionDescription(Languages.POLISH, "Przejdź do mapy świata")]
        [ActionDescription(Languages.ENGLISH, "Go to world map")]
        void GoToWorldMap();

        [ActionDescription(Languages.POLISH, "Wyślij atak na wioskę")]
        [ActionDescription(Languages.ENGLISH, "Send attack to a village")]
        void AttackVillage(
            [ParameterDescription(Languages.POLISH, "Współrzędna X", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "Współrzędna Y", ParameterTypes.Int)]
            int coordinateX,

            [ParameterDescription(Languages.POLISH, "Coordinate X", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "Coordinate Y", ParameterTypes.Int)]
            int coordinateY,

            [ParameterDescription(Languages.POLISH, "Ilość pikinierów", ParameterTypes.Int)]
            [ParameterDescription(Languages.ENGLISH, "Spearmen count", ParameterTypes.Int)]
            int pikemenCount);
    }
}