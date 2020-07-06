using System;

namespace Plemiona.Core.Interfaces.Steps
{
    public interface IStep
    {
        event Action<int> OnDelay;

        object Execute(object parameter = null);
    }
}