using PleAutomiX.Bots.WebDriver;
using PleAutomiX.Logic.Services.Helpers.ReflectionHelper;

namespace PleAutomiX.Logic.Services.ActionExecute
{
    public class ActionExecuteService : IActionExecuteService
    {
        private readonly IWebDriverProvider _plemiona;
        private readonly IReflectionService _reflectionService;

        public ActionExecuteService(
            IWebDriverProvider plemiona,
            IReflectionService reflectionService)
        {
            _plemiona = plemiona;
            _reflectionService = reflectionService;
        }

        public void ExecuteAction(string actionText, params object[] arguments)
        {
            var actionMethod = _reflectionService.GetActionMethodByActionText(actionText);

            actionMethod.Invoke(_plemiona, arguments);
        }
    }
}