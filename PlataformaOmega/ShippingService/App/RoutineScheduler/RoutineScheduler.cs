using ShippingService.App.RoutineSchedulerRoutines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.App
{
    public class RoutineScheduler
    {
        public static void Initialize()
        {
            try
            {
                CreateRoutine(new PackageWatcherRoutine());
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void CreateRoutine(IRoutine routine)
        {
            try
            {
                var timer = new Timer(new TimerCallback(routine.Callback), null, 0, routine.CallbackIntervalInMilliseconds);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
