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
        private static List<Timer> Routines { get; set; } = new List<Timer>();
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
                PushRoutineToHeap(timer);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void PushRoutineToHeap(Timer routine)
        {
            try
            {
                Routines.Add(routine);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
