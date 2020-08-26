using ShippingService.RoutineSchedulerRoutines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService
{
    public class RoutineScheduler
    {
        private static List<IRoutine> Routines { get; set; } = new List<IRoutine>();

        public static void Initialize()
        {
            try
            {
                CreateRoutine(new AutoUpdateRoutine());
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

        public static RoutineStates GetRoutineStates(string name)
        {
            try
            {
                var routine = Routines.Find(_routine => _routine.Name == name);

                if (routine != null)
                {
                    return routine.States;
                }
                else
                {
                    throw new Exception($"Rotina de nome {name} não existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static RoutineDates GetRoutineDates(string name)
        {
            try
            {
                var routine = Routines.Find(_routine => _routine.Name == name);

                if (routine != null)
                {
                    return routine.Dates;
                }
                else
                {
                    throw new Exception($"Rotina de nome {name} não existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void PauseRoutine(string name)
        {
            try
            {
                var routine = Routines.Find(_routine => _routine.Name == name);

                if(routine != null)
                {
                    routine.Pause().Wait();
                }
                else
                {
                    throw new Exception($"Rotina de nome {name} não existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void ResumeRoutine(string name)
        {
            try
            {
                var routine = Routines.Find(_routine => _routine.Name == name);

                if (routine != null)
                {
                    routine.Resume().Wait();
                }
                else
                {
                    throw new Exception($"Rotina de nome {name} não existe");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void RunRoutine(string name)
        {
            try
            {
                var routine = Routines.Find(_routine => _routine.Name == name);

                if (routine != null)
                {
                    routine.Run().Wait();
                }
                else
                {
                    throw new Exception($"Rotina de nome {name} não existe");
                }
            }
            catch (Exception)
            {
                throw;
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
