using System;

namespace PleAutomiX.Logic.Services.Helpers.Input
{
    public class InputService : IInputService
    {
        public string GetString(string message)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            return input;
        }

        public int GetInt(string message)
        {
            var value = GetValue(message, input => int.TryParse(input, out _), input => int.Parse(input));

            return value;
        }

        public bool GetBool(string message)
        {
            var value = GetValue(message, input => bool.TryParse(input, out _), input => bool.Parse(input));

            return value;
        }

        public DateTime GetDateTime(string message)
        {
            var value = GetValue(message, input => DateTime.TryParse(input, out _), input => DateTime.Parse(input));

            return value;
        }

        public TimeSpan GetTimepan(string message)
        {
            var value = GetValue(message, input => TimeSpan.TryParse(input, out _), input => TimeSpan.Parse(input));

            return value;
        }

        private TInput GetValue<TInput>(string message, Func<string, bool> isInpuctCorrect, Func<string, TInput> convertToValueType)
        {
            while (true)
            {
                string input = GetString(message);

                bool isInputCorrect = isInpuctCorrect(input);

                if (isInputCorrect)
                {
                    var value = convertToValueType(input);

                    return value;
                }
            }
        }
    }
}