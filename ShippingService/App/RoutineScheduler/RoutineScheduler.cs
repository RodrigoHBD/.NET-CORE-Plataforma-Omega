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
        private static List<IRoutine> Routines { get; set; } = new List<IRoutine>();
        public static void Initialize()
        {
            try
            {
                CreateRoutine(new PackageWatcherRoutine2());
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
                PushRoutineToHeap(routine);
                routine.Start().Wait();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void PushRoutineToHeap(IRoutine routine)
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
