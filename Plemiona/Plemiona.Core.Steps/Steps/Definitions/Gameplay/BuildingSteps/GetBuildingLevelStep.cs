using OpenQA.Selenium;
using Plemiona.Core.Enums;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Steps.Base;
using System;
using System.Linq;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetBuildingLevelStep : ComplexStepBase
    {
        public GetBuildingLevelStep(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService
            ) : base(
                webDriverProviderService,
                plemionaMetadataProviderService,
                webDriverBaseMethodsService,
                stepDelayService,
                botCheckDetectService)
        {
        }

        public override object Execute(object buildingType)
        {
            string buildingXPath = null;

            switch (buildingType)
            {
                case BuildingTypes.Townhall: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=main"; break;
                case BuildingTypes.Barracks: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=barracks"; break;
                case BuildingTypes.Stable: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=stable"; break;
                case BuildingTypes.Workshop: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=garage"; break;
                case BuildingTypes.Palace: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=snob"; break;
                case BuildingTypes.Forge: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=smith"; break;
                case BuildingTypes.Yard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=place"; break;
                case BuildingTypes.Statue: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=statue"; break;
                case BuildingTypes.Market: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=market"; break;
                case BuildingTypes.Sawmill: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=wood"; break;
                case BuildingTypes.Brickyard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=stone"; break;
                case BuildingTypes.Ironworks: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=iron"; break;
                case BuildingTypes.Farm: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=farm"; break;
                case BuildingTypes.Storage: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=storage"; break;
                case BuildingTypes.Clipboard: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=hide"; break;
                case BuildingTypes.Wall: buildingXPath = $"/game.php?village={_plemionaMetadata.VillageId}&screen=wall"; break;
                default: throw new NotImplementedException();
            }

            int buildingLevel = GetBuildingLevel(buildingXPath);

            return buildingLevel;
        }

        private int GetBuildingLevel(string buildingHref)
        {
            IWebElement buildingElement = null;

            try
            {
                buildingElement = _remoteWebDriver.FindElementByXPath($"//td/a[@href='{buildingHref}']/parent::td/span");
            }
            catch (NoSuchElementException)
            {
                // Building was not found. Returning level 0.
                return 0;
            }

            string buildingLevelText = buildingElement.Text;

            string buildingLevelString = string.Join(string.Empty, buildingLevelText.Where(c => char.IsNumber(c)));

            // Building label contains "not built". Returning level 0.
            int.TryParse(buildingLevelString, out int buildingLevel);

            return buildingLevel;
        }
    }
}