using PleAutomiX.Game.Attributes;
using PleAutomiX.Translation.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PleAutomiX.Logic.Services.Helpers.ReflectionHelper
{
    public class ReflectionService<TPlemiona> : IReflectionService
    {
        public MethodInfo GetActionMethodByActionText(string actionText)
        {
            var actionMethods = GetActionMethods();

            var actionMethod = actionMethods.Single(am => GetActionDescriptions(am).Any(d => d.Text == actionText));

            return actionMethod;
        }

        public IEnumerable<MethodInfo> GetActionMethods()
        {
            var actionMethods = typeof(TPlemiona).GetMethods(BindingFlags.Instance | BindingFlags.Public);

            return actionMethods;
        }

        public IEnumerable<ActionDescriptionAttribute> GetActionDescriptions(MethodInfo action)
        {
            var actionDescriptions = action.GetCustomAttributes<ActionDescriptionAttribute>();

            return actionDescriptions;
        }

        public IEnumerable<ParameterDescriptionAttribute> GetActionParametersDescriptions(MethodInfo action)
        {
            var actionParameters = action.GetParameters();

            var actionParametersDescriptions = actionParameters.SelectMany(ap => ap.GetCustomAttributes<ParameterDescriptionAttribute>());

            return actionParametersDescriptions;
        }
    }
}