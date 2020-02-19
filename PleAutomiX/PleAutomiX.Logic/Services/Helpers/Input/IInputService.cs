using System;

namespace PleAutomiX.Logic.Services.Helpers.Input
{
    public interface IInputService
    {
        string GetString(string message);

        int GetInt(string message);

        bool GetBool(string message);

        DateTime GetDateTime(string message);
        
        TimeSpan GetTimepan(string message);
    }
}