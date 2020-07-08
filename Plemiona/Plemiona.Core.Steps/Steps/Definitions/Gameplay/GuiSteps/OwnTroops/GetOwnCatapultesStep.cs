﻿using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnCatapultesStep : StandardStepBase
    {
        public GetOwnCatapultesStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object parameter)
        {
            try
            {
                string catapultesCountText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='catapult']"));

                int catapultesCount = Convert.ToInt32(catapultesCountText);

                return catapultesCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}