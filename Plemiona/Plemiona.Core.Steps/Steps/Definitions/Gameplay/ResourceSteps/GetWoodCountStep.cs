using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.BuildingSteps
{
    public class GetWoodCountStep : StandardStepBase, IStep
    {
        public GetWoodCountStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            string woodCountString = _webDriverBaseMethodsService.GetTextBy(By.Id("wood"));

            int woodCount = Convert.ToInt32(woodCountString);

            return woodCount;
        }
    }
}