using ShippingService.App.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.RoutineSchedulerRoutines
{
    public class AutoUpdateRoutine : IRoutine
    {
        public string Name { get; set; } = "AutoUpdate";

        public int CallbackIntervalInMilliseconds { get; } = 100000;

        public RoutineStates States { get; set; } = new RoutineStates();

        public RoutineDates Dates { get; set; } = new RoutineDates();

    public async Task Start()
        {
            await Run();
        }

        public Task End()
        {
            throw new NotImplementedException();
        }

        public Task Pause()
        {
            throw new NotImplementedException();
        }

        public Task Resume()
        {
            throw new NotImplementedException();
        }

        public async Task Run()
        {
            await UseCaseOperator.RunShipmentAutoUpdate();
        }


    }
}
