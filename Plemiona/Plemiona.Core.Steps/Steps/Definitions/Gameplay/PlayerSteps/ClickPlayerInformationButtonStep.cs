﻿using OpenQA.Selenium;
using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;

namespace Plemiona.Core.Steps.Steps.Definitions.Gameplay.TroopSteps
{
    public class ClickPlayerInformationButtonStep : StandardStepBase, IStep
    {
        public ClickPlayerInformationButtonStep(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
            : base(webDriverBaseMethodsService, stepDelayService)
        {
        }

        public object Execute(object parameter)
        {
            _stepDelayService.Delay();

            _webDriverBaseMethodsService.ClickBy(By.XPath($"//*[@href='/game.php?village={_plemionaMetadata.VillageId}&screen=info_player']"));

            return null;
        }
    }
}