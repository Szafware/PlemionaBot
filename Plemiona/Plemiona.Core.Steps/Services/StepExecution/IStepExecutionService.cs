using System;

namespace Plemiona.Core.Steps.Services.StepExecution
{
    public interface IStepExecutionService
    {
        event Action<int> OnDelay;

        event Action<string, DateTime> OnStepExecutionStart;

        event Action<string, DateTime, long, bool> OnStepExecutionEnd;

        object Execute(string stepName, object parameter = null);

        TResult Execute<TResult>(string stepName, object parameter = null);
    }
}