namespace PleAutomiX.Logic.Services.ActionExecute
{
    public interface IActionExecuteService
    {
        void ExecuteAction(string actionText, params object[] arguments);
    }
}