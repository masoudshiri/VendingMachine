using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace VendoreMachine.Common
{
    public class ProccessBuilder : IProccessBuilder
    {
        List<Func<bool>> _makingProcess = new List<Func<bool>>();
        public event Action<bool> Complished;
        public event Action<int> StepFinished;
        public event Action<int> StepStarted;
        BlockingCollection<object>[] _buffers;
        CancellationTokenSource stopFlag;
        public void AddToProccess(Func<bool> func)
        {
            _makingProcess.Add(func);
        }
        public void Execute(object input)
        {
            stopFlag = new CancellationTokenSource();
            var first = _buffers[0];
            first.Add(input);
        }
        public void StopExecuting(int index)
        {
            stopFlag.Cancel();
            _buffers[index].CompleteAdding();
        }
        public ProccessBuilder GetBuilder()
        {
            stopFlag = new CancellationTokenSource();
            _buffers = _makingProcess
            .Select(step => new BlockingCollection<object>())
            .ToArray();

            int bufferIndex = 0;
            foreach (var pipelineStep in _makingProcess)
            {
               var bufferIndexLocal = bufferIndex;
                Task.Run(() =>
                {
                Thread t = Thread.CurrentThread;
                    using (stopFlag.Token.Register(t.Abort))
                    {
                        foreach (var input in _buffers[bufferIndexLocal].GetConsumingEnumerable(stopFlag.Token))
                        {

                            this.StepStarted?.Invoke(bufferIndexLocal);
                            bool output = pipelineStep.Invoke();
                            this.StepFinished?.Invoke(bufferIndexLocal);
                            bool isLastStep = bufferIndexLocal == _makingProcess.Count - 1;
                            if (isLastStep)
                                this.Complished?.Invoke(true);
                            else
                            {
                                var next = _buffers[bufferIndexLocal + 1];
                                next.Add(output);
                            }

                        }
                    }
                },stopFlag.Token);
                bufferIndex++;
            }
            return this;
        }
    }
}
