using Plemiona.Core.Models;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class StandardStepBase
    {
        protected IWebDriverBaseMethodsService _webDriverBaseMethodsService;
        protected static IStepDelayService _stepDelayService;
        protected IBotCheckDetectService _botCheckDetectService;

        protected readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        protected readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        protected static PlemionaMetadata _plemionaMetadata;

        public StandardStepBase(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
        {
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
            _stepDelayService = stepDelayService;
            _botCheckDetectService = botCheckDetectService;
        }
    }
}