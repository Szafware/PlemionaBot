using Plemiona.Core.Models;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using Plemiona.Core.Services.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class StandardStepBase : Step
    {
        protected readonly IWebDriverBaseMethodsService _webDriverBaseMethodsService;

        protected readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        protected readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        protected static PlemionaMetadata _plemionaMetadata;

        public StandardStepBase(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
            : base(stepDelayService, botCheckDetectService)
        {
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
        }
    }
}