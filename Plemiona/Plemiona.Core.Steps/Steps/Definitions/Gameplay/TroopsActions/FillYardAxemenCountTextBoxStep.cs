﻿using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.VillageName
{
    public class FillYardAxemenCountTextBoxStep : StandardStepBase, IStep
    {
        public FillYardAxemenCountTextBoxStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object count)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.FillBy(By.Id("unit_input_axe"), count.ToString());

            return null;
        }
    }
}