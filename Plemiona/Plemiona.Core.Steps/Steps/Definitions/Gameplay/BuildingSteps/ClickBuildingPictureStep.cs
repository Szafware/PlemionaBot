using OpenQA.Selenium;
using Plemiona.Core.Enums;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class ClickBuildingPictureStep : StandardStepBase
    {
        public ClickBuildingPictureStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object buildingType)
        {
            base.Execute(GetType().Name);

            string buildingXPath = null;

            switch ((BuildingTypes)buildingType)
            {
                case BuildingTypes.Townhall: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main']"; break;
                case BuildingTypes.Barracks: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=barracks']"; break;
                case BuildingTypes.Stable: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=stable']"; break;
                case BuildingTypes.Workshop: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=garage']"; break;
                case BuildingTypes.Palace: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=snob']"; break;
                case BuildingTypes.Forge: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=smith']"; break;
                case BuildingTypes.Yard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=place']"; break;
                case BuildingTypes.Statue: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=statue']"; break;
                case BuildingTypes.Market: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=market']"; break;
                case BuildingTypes.Sawmill: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=wood']"; break;
                case BuildingTypes.Brickyard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=stone']"; break;
                case BuildingTypes.Ironworks: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=iron']"; break;
                case BuildingTypes.Farm: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=farm']"; break;
                case BuildingTypes.Storage: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=storage']"; break;
                case BuildingTypes.Clipboard: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=hide']"; break;
                case BuildingTypes.Wall: buildingXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=wall']"; break;
                default: throw new NotImplementedException();
            }

            _webDriverBaseMethodsService.ClickBy(By.XPath(buildingXPath));

            return null;
        }
    }
}