using PleAutomiX.Game.Attributes;
using System.Collections.Generic;

namespace PleAutomiX.Logic.Services.Translation
{
    public interface ITranslationService
    {
        IEnumerable<string> GetActionTexts();

        IEnumerable<ParameterDescriptionAttribute> GetActionParameterNames(string actionText);
    }
}