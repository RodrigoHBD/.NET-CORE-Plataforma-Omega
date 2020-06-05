using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;
using ShippingService.App.RoutineSchedulerRoutines.PackageWatcher;
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
        private static PackageWatcherSearch InitialSearchParams = new PackageWatcherSearch();

        public static int DefaultSearchLimit { get; } = 1;

        public int CallbackIntervalInMilliseconds { get; } = 10000;

        public void Callback(object data)
        {
            try
            {
                var routineControl = new RoutineControl();
                var starterSearch = SearchWatchers(InitialSearchParams).Result;

                routineControl.WathersTotalNumber = starterSearch.Pagination.Total;
                LoopSearch(routineControl);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Routine Exception ->> {e.Message}");
                Console.WriteLine($"Stack Trace ->> {e.StackTrace}");
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
                throw e;
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


    }
}
