using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.BotCheckDetect;
using Plemiona.Core.Services.Delay.Step;
using System;

namespace Plemiona.Core.Steps.Steps.Base
{
    public abstract class Step : IStep
    {
        protected static IStepDelayService _stepDelayService;
        protected readonly IBotCheckDetectService _botCheckDetectService;

        public event Action<int> OnDelay;

        public Step(
            IStepDelayService stepDelayService,
            IBotCheckDetectService botCheckDetectService)
        {
            _stepDelayService = stepDelayService;
            _botCheckDetectService = botCheckDetectService;

            _stepDelayService.OnDelay += stepDelayMilliseconds => OnDelay?.Invoke(stepDelayMilliseconds);
        }

        public virtual object Execute(object stepName)
        {
            _botCheckDetectService.Validate(stepName.ToString());
            _stepDelayService.Delay();
            return null;
        }
    }
}