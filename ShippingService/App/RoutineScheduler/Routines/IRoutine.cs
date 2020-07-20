using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.App
{
    interface IRoutine
    {
        public string Name { get; set; }
        public int CallbackIntervalInMilliseconds { get; }
        public bool IsPaused { get; set; }
        public Timer RoutineTimer { get; set; }
        public Task Start();
        public Task Pause();
        public Task Resume();
        public Task End();
        public Task Run();
        public void TimerCallback(object state);
    }
}
