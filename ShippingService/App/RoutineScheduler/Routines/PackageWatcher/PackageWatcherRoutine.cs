using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using ShippingService.App.UseCases;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.App.RoutineSchedulerRoutines
{
    public class PackageWatcherRoutine : IRoutine
    {
        private static PackageWatcherSearch InitialSearchParams = new PackageWatcherSearch();

        private static bool IsExecuting { get; set; } = false;

        public static int DefaultSearchLimit { get; } = 1;

        public string Name { get; set; } = "PackageWatcher";

        public int CallbackIntervalInMilliseconds { get; } = 14400000;

        public Timer RoutineTimer { get; set; }
        public bool IsPaused { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RoutineStates States { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public RoutineDates Dates { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Callback(object data)
        {
            try
            {
                if (IsExecuting)
                {
                    return;
                }

                var watch = new Stopwatch();
                watch.Start();

                IsExecuting = true;
                var routineControl = new RoutineControl();
                var starterSearch = SearchWatchers(InitialSearchParams).Result;

                routineControl.WathersTotalNumber = starterSearch.Pagination.Total;
                LoopSearch(routineControl);
                watch.Stop();
                Console.WriteLine($"Package Watcher Routine Cicle Fineshed. Elapsed Time: {watch.Elapsed}");
                IsExecuting = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("----------- Package Watcher Routine Exception ------------------");
                Console.WriteLine(e);
            }
        }

        private async Task<IPackageWatcherList> SearchWatchers(IPackageWatcherSearch search)
        {
            try
            {
                return await UseCaseOperator.SearchPackageWatchersAsync(search);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void LoopSearch(RoutineControl routineControl)
        {
            try
            {
               while(routineControl.WathersTotalNumber > routineControl.CurrentIteration)
                {
                    var search = BuildSearchObject(routineControl);
                    var watcher = SearchWatchers(search).Result.Watchers.First();

                    UseCaseOperator.RunWatcherRoutine(watcher.PackageId).Wait();
                    IncrementRoutineControl(routineControl);
                }
            }
            catch (Exception e)
            {
                if (e.InnerException != null)
                {
                    e = e.InnerException;
                }
                Console.WriteLine("----------- Package Watcher Routine LOOP Exeption ------------------");
                Console.WriteLine(e);
            }
        }

        private PackageWatcherSearch BuildSearchObject(RoutineControl routineControl)
        {
            try
            {
                return new PackageWatcherSearch()
                {
                    Pagination = new PaginationIn()
                    {
                        Offset = routineControl.CurrentIteration,
                        Limit = 1
                    }
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void IncrementRoutineControl(RoutineControl routineControl)
        {
            routineControl.CurrentIteration++;
        }

        public Task Start()
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

        public Task End()
        {
            throw new NotImplementedException();
        }

        public Task Run()
        {
            throw new NotImplementedException();
        }

        public void TimerCallback(object state)
        {
            throw new NotImplementedException();
        }
    }
}
