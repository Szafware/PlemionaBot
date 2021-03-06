﻿using System;
using System.Threading;

namespace Plemiona.Core.Services.Delay.Step
{
    public class RandomTypingDelayService : ITypingDelayService
    {
        private readonly Random _random = new Random();
        private readonly object _lock = new object();

        private int _minimumMilliseconds = 20;
        private int _maximumMilliseconds = 250;

        public void Configure(int minimumMilliseconds, int maximumMilliseconds)
        {
            if (minimumMilliseconds > maximumMilliseconds)
            {
                throw new Exception("Minimum milliseconds cannot be greater than maximum milliseconds.");
            }

            _minimumMilliseconds = minimumMilliseconds;
            _maximumMilliseconds = maximumMilliseconds;
        }

        public void Delay()
        {
            lock (_lock)
            {

                var millisecondsDelay = _minimumMilliseconds == _maximumMilliseconds ?
                    _minimumMilliseconds :
                    _random.Next(_minimumMilliseconds, _maximumMilliseconds);

                Thread.Sleep(millisecondsDelay); 
            }
        }
    }
}