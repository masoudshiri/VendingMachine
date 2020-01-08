using System;
namespace VendoreMachine.Common
{
    public interface IProccessBuilder
    {
        void Execute(object input);
        void StopExecuting(int index);
        event Action<int> StepStarted;
        event Action<int> StepFinished;
        event Action<bool> Complished;
    }
}
