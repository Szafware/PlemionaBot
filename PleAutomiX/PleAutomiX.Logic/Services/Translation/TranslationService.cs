using PleAutomiX.Game.Attributes;
using PleAutomiX.Logic.Models;
using PleAutomiX.Logic.Services.Helpers.ReflectionHelper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PleAutomiX.Logic.Services.Translation
{
    public class TranslationService : ITranslationService
    {
        private readonly AppSettings _appSettings;
        private readonly IReflectionService _reflectionService;

        public TranslationService(
            AppSettings appSettings,
            IReflectionService reflectionService)
        {
            _appSettings = appSettings;
            _reflectionService = reflectionService;
        }

        public IEnumerable<string> GetActionTexts()
        {
            var actionMethods = _reflectionService.GetActionMethods();

            var actionDescriptions = actionMethods.SelectMany(am => _reflectionService.GetActionDescriptions(am));

            var currentLanguageActionDescriptions = actionDescriptions.Where(at => at.Language == _appSettings.CurrentLanguage);

            var currentLanguageActionTexts = currentLanguageActionDescriptions.Select(at => at.Text);

            return currentLanguageActionTexts;
        }

        public IEnumerable<ParameterDescriptionAttribute> GetActionParameterNames(string actionText)
        {
            var actionMethod = _reflectionService.GetActionMethodByActionText(actionText);

            var actionArgumentsDescriptions = _reflectionService.GetActionParametersDescriptions(actionMethod);

            var currentLanguageArgumentsDescriptions = actionArgumentsDescriptions.Where(at => at.Language == _appSettings.CurrentLanguage);

            return currentLanguageArgumentsDescriptions;
        }
    }
}