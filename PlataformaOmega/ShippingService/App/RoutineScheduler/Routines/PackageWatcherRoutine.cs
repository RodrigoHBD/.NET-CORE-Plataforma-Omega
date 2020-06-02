using ShippingService.App.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.App.RoutineSchedulerRoutines
{
    public class PackageWatcherRoutine : IRoutine
    {
        public int CallbackIntervalInMilliseconds { get; } = 5000;

        public void Callback(object data)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
