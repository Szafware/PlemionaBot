using PleAutomiX.Bots.Features;
using PleAutomiX.Bots.Steps.Steps;
using PleAutomiX.Bots.Steps.WebDriverBase;
using PleAutomiX.Bots.WebDriver;
using PleAutomiX.DependencyInjection;
using PleAutomiX.Logic.Models;
using PleAutomiX.Logic.Services.ActionExecute;
using PleAutomiX.Logic.Services.Helpers.Input;
using PleAutomiX.Logic.Services.Helpers.ReflectionHelper;
using PleAutomiX.Logic.Services.Translation;
using PleAutomiX.Translation.Constants;
using PleAutomiX.Translation.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PleAutomiX.ConsoleApp
{
    public class Program
    {
        private static readonly IContainer _container = new NInjectContainer();

        private static AppSettings _appSettings;
        private static IActionExecuteService _actionExecuteService;
        private static ITranslationService _translationService;
        private static IInputService _inputService;

        public static void Main(string[] args)
        {
            var seleniumDriverProvider = new SeleniumWebDriverProvider();
            IPlemionaFeatures plemionaComposites = new PlemionaFeatures(new PlemionaSteps(seleniumDriverProvider, new WebDriverBaseMethods(seleniumDriverProvider)));
            plemionaComposites.SignIn("Dziaczakra", "AmIpro94", 146);
            //plemionaComposites.RecruitKnight("Chrobry");
            //plemionaComposites.ChangeVillageName("Tajna Baza");
            var buildings = plemionaComposites.GetCurrentVillageBuildings();
            Console.ReadKey();
        }

        private static void DisplayPossibleActionTexts(IEnumerable<string> possibleActionTexts)
        {
            Console.WriteLine("\n");

            int actionNumber = 1;

            foreach (string actionText in possibleActionTexts)
            {
                string actionMessage = $"{actionNumber}. {actionText}";

                Console.WriteLine(actionMessage);

                actionNumber++;
            }
        }

        private static string GetActionTextToExecute(IEnumerable<string> possibleActionTexts)
        {
            Console.Write("\nWykonaj akcję: ");
            int actionNumberToExecute = Convert.ToInt32(Console.ReadLine());

            string actionTextToExecute = possibleActionTexts.ToList()[actionNumberToExecute - 1];

            return actionTextToExecute;
        }

        private static IEnumerable<object> GetActionParameters(string actionText)
        {
            var actionParameterDescriptions = _translationService.GetActionParameterNames(actionText);

            var actionParameters = new List<object>();

            foreach (var actionParameterDescription in actionParameterDescriptions)
            {
                object actionParameter = null;

                switch (actionParameterDescription.ParameterType)
                {
                    case ParameterTypes.String:
                        actionParameter = _inputService.GetString($"{actionParameterDescription.Text}: ");
                        break;
                    case ParameterTypes.Int:
                        actionParameter = _inputService.GetInt($"{actionParameterDescription.Text}: ");
                        break;
                    case ParameterTypes.Bool:
                        actionParameter = _inputService.GetBool($"{actionParameterDescription.Text}: ");
                        break;
                    case ParameterTypes.DateTime:
                        actionParameter = _inputService.GetDateTime($"{actionParameterDescription.Text}: ");
                        break;
                    case ParameterTypes.TimeSpan:
                        actionParameter = _inputService.GetTimepan($"{actionParameterDescription.Text}: ");
                        break;
                }

                actionParameters.Add(actionParameter);
            }

            return actionParameters;
        }

        private static void DependencyInjectionBinding()
        {
            _container.BindToSelfAsSingleton<AppSettings>();

            _container.Bind<IWebDriverProvider, SeleniumWebDriverProvider>();
            _container.Bind<IActionExecuteService, ActionExecuteService>();
            _container.Bind<IReflectionService, ReflectionService<IPlemionaFeatures>>();
            _container.Bind<ITranslationService, TranslationService>();
            _container.Bind<IInputService, InputService>();

            _appSettings = _container.GetImplementation<AppSettings>();
            _appSettings.CurrentLanguage = Languages.POLISH;

            _actionExecuteService = _container.GetImplementation<IActionExecuteService>();
            _translationService = _container.GetImplementation<ITranslationService>();
            _inputService = _container.GetImplementation<IInputService>();
        }
    }
}