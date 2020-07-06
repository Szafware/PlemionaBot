using Plemiona.Core.Interfaces.Steps;
using System.Collections.Generic;

namespace Plemiona.Core.Steps.Services.StepProvider
{
    public interface IStepProviderService
    {
        IStep GetStep(string stepKey);

        IEnumerable<IStep> GetAllStep();

        IEnumerable<string> GetStepKeys();
    }
}