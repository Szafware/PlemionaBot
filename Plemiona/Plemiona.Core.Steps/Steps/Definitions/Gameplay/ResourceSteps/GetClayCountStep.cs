using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetClayCountStep : StandardStepBase, IStep
    {
        public GetClayCountStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            string clayCountString = _webDriverBaseMethodsService.GetTextBy(By.Id("stone"));

            int clayCount = Convert.ToInt32(clayCountString);

            return clayCount;
        }
    }
}