using OpenQA.Selenium;
using Plemiona.Core.Enums;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using System;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class ClickAddBuildingToBuildQueueButtonStep : StandardStepBase, IStep
    {
        public ClickAddBuildingToBuildQueueButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object buildingType)
        {
            _botCheckDetectService.Validate(nameof(ClickAddBuildingToBuildQueueButtonStep));
            _stepDelayService.Delay();

            string addBuildingToBuildQueueButtonXPath = null;

            switch (buildingType)
            {
                case BuildingTypes.Townhall: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=main&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Barracks: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=barracks&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Stable: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=stable&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Workshop: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=garage&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Palace: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=snob&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Forge: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=smith&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Yard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=place&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Statue: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=statue&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Market: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=market&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Sawmill: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=wood&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Brickyard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=stone&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Ironworks: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=iron&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Farm: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=farm&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Storage: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=storage&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Clipboard: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=hide&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                case BuildingTypes.Wall: addBuildingToBuildQueueButtonXPath = $"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=main&action=upgrade_building&id=wall&type=main&h={_plemionaMetadata.CsrfToken}']"; break;
                default: throw new NotImplementedException();
            }

            _webDriverBaseMethodsService.ClickBy(By.XPath(addBuildingToBuildQueueButtonXPath));

            return null;
        }
    }
}