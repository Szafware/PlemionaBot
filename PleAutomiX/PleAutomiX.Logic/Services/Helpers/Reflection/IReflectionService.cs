using PleAutomiX.Game.Attributes;
using PleAutomiX.Translation.Attributes;
using System.Collections.Generic;
using System.Reflection;

namespace PleAutomiX.Logic.Services.Helpers.ReflectionHelper
{
    public interface IReflectionService
    {
        MethodInfo GetActionMethodByActionText(string actionText);

        IEnumerable<MethodInfo> GetActionMethods();

        IEnumerable<ActionDescriptionAttribute> GetActionDescriptions(MethodInfo action);

        IEnumerable<ParameterDescriptionAttribute> GetActionParametersDescriptions(MethodInfo action);
    }
}