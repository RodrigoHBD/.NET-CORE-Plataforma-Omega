using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService
{
    public interface IRoutine
    {
        public string Name { get; set; }
        public int CallbackIntervalInMilliseconds { get; }
        public RoutineStates States { get; set; }
        public RoutineDates Dates { get; set; }
        public Task Start();
        public Task End();
        public Task Pause();
        public Task Resume();
        public Task Run();
    }

    public class RoutineStates 
    {
        public bool IsPaused { get; set; }
        public bool IsExecuting { get; set; }
        public bool IsInitialized { get; set; }
    }

    public class RoutineDates
    {
        public DateTime LastExecutedAt { get; set; }
        public DateTime NextExecutionAt { get; set; }
    }
}
