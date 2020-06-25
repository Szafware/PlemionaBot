using Plemiona.Core.Interfaces.Steps;
using Plemiona.Core.Services.PlemionaMetadataProvider;
using Plemiona.Core.Services.WebDriverProvider;
using Plemiona.Core.Steps.Services.Delay.Step;
using Plemiona.Core.Steps.Steps.Base;
using Plemiona.Core.Steps.WebDriverBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Plemiona.Core.Steps.Services.StepProvider
{
    public class StepProviderService : IStepProviderService
    {
        private readonly Dictionary<string, IStep> _steps = new Dictionary<string, IStep>();

        public StepProviderService(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
        {
            LoadSteps(webDriverProviderService, plemionaMetadataProviderService, webDriverBaseMethodsService, stepDelayService);
        }

        public IStep GetStep(string stepKey)
        {
            var step = _steps[stepKey];

            return step;
        }

        public IEnumerable<string> GetStepKeys()
        {
            var stepKeys = _steps.Keys;

            return stepKeys;
        }

        private void LoadSteps(
            IWebDriverProviderService webDriverProviderService,
            IPlemionaMetadataProviderService plemionaMetadataProviderService,
            IWebDriverBaseMethodsService webDriverBaseMethodsService,
            IStepDelayService stepDelayService)
        {
            var executingAssembly = Assembly.GetExecutingAssembly();

            var types = executingAssembly.GetTypes();

            var stepTypes = types.Where(t => t.GetInterfaces().Contains(typeof(IStep)));

            foreach (var stepType in stepTypes)
            {
                IStep stepInstance = null;

                if (stepType.IsSubclassOf(typeof(ComplexStepBase)))
                {
                    stepInstance = (IStep)Activator.CreateInstance(stepType, webDriverProviderService, plemionaMetadataProviderService, webDriverBaseMethodsService, stepDelayService);
                }
                else if (stepType.IsSubclassOf(typeof(StandardStepBase)))
                {
                    stepInstance = (IStep)Activator.CreateInstance(stepType, webDriverBaseMethodsService, stepDelayService);
                }

                else
                {
                    throw new Exception($"Step \"{stepType.Name}\" does not inherit any of known step base classes.");
                }

                string stepName = GetStepName(stepType);

                _steps.Add(stepName, stepInstance);
            }
        }

        private string GetStepName(Type stepType)
        {
            string stepClassName = stepType.Name;

            string stepSufix = "Step";

            if (!stepClassName.EndsWith(stepSufix))
            {
                throw new ArgumentException("Incorrect step class name", stepClassName);
            }

            int stepNameCharacterCount = stepClassName.Length - stepSufix.Length;

            string stepName = stepClassName.Substring(0, stepNameCharacterCount);

            return stepName;
        }
    }
}