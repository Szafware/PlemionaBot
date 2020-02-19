using System;

namespace PleAutomiX.Logic.Services.Helpers.Randomness
{
    public class RandomnessService : IRandomnessService
    {
        private readonly Random _random = new Random();

        private readonly object _lock = new object();

        public int GetRandomInt(int from, int to)
        {
            lock (_lock)
            {
                int randomInt = _random.Next(from, to + 1);

                return randomInt;
            }
        }
    }
}