﻿using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.GuiSteps.VillageInformation
{
    public class GetOwnScoutsStep : StandardStepBase
    {
        public GetOwnScoutsStep(
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
                string scoutsText = _webDriverBaseMethodsService.GetTextBy(By.XPath("//strong[@data-count='spy']"));

                int scoutsCount = Convert.ToInt32(scoutsText);

                return scoutsCount;
            }
            catch (NoSuchElementException)
            {
                return 0;
            }
        }
    }
}