using Plemiona.Core.Models;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.WebDriverBase;
using System;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class StandardStepBase
    {
        private protected IWebDriverBaseMethodsService _webDriverBaseMethodsService;
        private static protected IStepDelayService _stepDelayService;

        protected readonly TimeSpan _timeoutForExpectedElements = TimeSpan.FromSeconds(5);
        protected readonly TimeSpan _timeoutForChceckingElementsExistence = TimeSpan.FromSeconds(2);

        protected static PlemionaMetadata _plemionaMetadata;

        public StandardStepBase(
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
        {
            _webDriverBaseMethodsService = webDriverBaseMethodsService;
            _stepDelayService = stepDelayService;
        }
    }
}