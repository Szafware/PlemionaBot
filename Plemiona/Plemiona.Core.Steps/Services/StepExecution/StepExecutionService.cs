using Plemiona.Core.Steps.Services.StepProvider;
using System;
using System.Diagnostics;
using System.Linq;

namespace Plemiona.Core.Steps.Services.StepExecution
{
    public class StepExecutionService : IStepExecutionService
    {
        public event Action<int> OnDelay;
        public event Action<string, DateTime> OnStepExecutionStart;
        public event Action<string, DateTime, long, bool> OnStepExecutionEnd;

        private readonly IStepProviderService _stepProviderService;

        public StepExecutionService(IStepProviderService stepProviderService)
        {
            _stepProviderService = stepProviderService;

            var steps = _stepProviderService.GetAllStep();

            // TODO: It's done this way probably because _delayService is a static field...
            steps.First().OnDelay += stepDelayMilliseconds => OnDelay?.Invoke(stepDelayMilliseconds);
        }

        public object Execute(string stepName, object parameter = null)
        {
            var step = _stepProviderService.GetStep(stepName);

            var stopwatch = Stopwatch.StartNew();

            OnStepExecutionStart?.Invoke(stepName, DateTime.Now);

            bool stepSuccess = true;

            try
            {
                var result = step.Execute(parameter);

                return result;
            }
            catch
            {
                stepSuccess = false;
                throw;
            }
            finally
            {
                long milliseconds = stopwatch.ElapsedMilliseconds;

                OnStepExecutionEnd?.Invoke(stepName, DateTime.Now, milliseconds, stepSuccess);

                stopwatch.Stop();
            }
        }

        public TResult Execute<TResult>(string stepName, object parameter = null)
        {
            var result = Execute(stepName, parameter);

            return (TResult)result;
        }
    }
}