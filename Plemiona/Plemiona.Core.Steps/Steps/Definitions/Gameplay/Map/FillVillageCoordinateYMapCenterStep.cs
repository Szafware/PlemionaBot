﻿using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Services.BotCheckDetect;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillVillageCoordinateYMapCenterStep : StandardStepBase, IStep
    {
        public FillVillageCoordinateYMapCenterStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public object Execute(object coordinateX)
        {
            _botCheckDetectService.Validate(nameof(FillVillageCoordinateYMapCenterStep));
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("mapy"), coordinateX.ToString());

            return null;
        }
    }
}