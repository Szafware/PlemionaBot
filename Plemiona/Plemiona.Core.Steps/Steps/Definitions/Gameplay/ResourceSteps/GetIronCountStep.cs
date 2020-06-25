using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetIronCountStep : StandardStepBase, IStep
    {
        public GetIronCountStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            string ironCountString = _webDriverBaseMethodsService.GetTextBy(By.Id("iron"));

            int ironCount = Convert.ToInt32(ironCountString);

            return ironCount;
        }
    }
}