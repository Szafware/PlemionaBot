﻿using OpenQA.Selenium;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using Plemiona.Core.Steps.Steps.Base;

namespace Plemiona.Core.Steps.Steps.Definitions.OutsideGameplay
{
    public class FillPasswordTextBoxStep : StandardStepBase
    {
        public FillPasswordTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(webDriverBaseMethodsService, stepDelayService, botCheckDetectService)
        {
        }

        public override object Execute(object password)
        {
            base.Execute(GetType().Name);

            _webDriverBaseMethodsService.FillBy(By.Id("password"), (string)password);

            return null;
        }
    }
}