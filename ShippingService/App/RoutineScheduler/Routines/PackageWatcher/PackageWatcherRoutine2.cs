using ShippingService.App.Models.Input;
using ShippingService.App.Models.Output;

using ShippingService.App.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ShippingService.App.RoutineSchedulerRoutines
{
    public class PackageWatcherRoutine2 : IRoutine
    {
        private static Timer _RoutineTimer { get; set; }
        public Timer RoutineTimer { get; set; }

        public string Name { get; set; }

        public int CallbackIntervalInMilliseconds { get; set; }

        public bool IsPaused { get; set; } = false;

        public bool IsInitialized { get; set; } = false;

        private bool IsExecuting { get; set; } = false;

        private bool ShouldExecute
        {
            get
            {
                if(!IsPaused && !IsExecuting)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private RoutineControl RoutineControl { get; set; } = new RoutineControl();

        private IPackageWatcherSearch SearchRequest { get; set; }

        public PackageWatcherRoutine2()
        {
            Name = "Package Watcher";
            CallbackIntervalInMilliseconds = 10000;   
        }

        private void InitializeTimer()
        {
            var callback = new TimerCallback(TimerCallback);
            _RoutineTimer = new Timer(callback, null, 0, CallbackIntervalInMilliseconds);
        }

        private void InitializeRoutineControl()
        {
            var search = SearchWatchers(SearchRequest).Result;
            RoutineControl.WathersTotalNumber = search.Pagination.Total;
            RoutineControl.CurrentIteration = 0;
        }

        private void SetInitialSearchRequest()
        {
            SearchRequest = GetInitialSearchReq();
        }

        public async Task Start()
        {
            InitializeTimer();
            IsInitialized = true;
        }

        public async Task End()
        {
            _RoutineTimer.Dispose();
            IsInitialized = false;
            IsPaused = false;
        }

        public async Task Pause()
        {
            IsPaused = true;
        }

        public async Task Run()
        {
            await ExecuteRoutine();
        }

        public void TimerCallback(object state)
        {
            if (ShouldExecute)
            {
                ExecuteRoutine().Wait();
            }
        }

        public async Task Resume()
        {
            IsPaused = false;
            await Run();
        }

        private void InitializeRoutine()
        {
            SetInitialSearchRequest();
            InitializeRoutineControl();
        }

        public async Task ExecuteRoutine()
        {
            try
            {
                IsExecuting = true;
                InitializeRoutine();
                Console.WriteLine("Routine Init");
                while (RoutineControl.WathersTotalNumber > RoutineControl.CurrentIteration)
                {
                    await RunSearchCicle();
                    IncrementSearchPagination();
                }
                Console.WriteLine("Routine Finish");
                IsExecuting = false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task RunSearchCicle()
        {
            try
            {
                var search = await SearchWatchers(SearchRequest);
                
                search.Watchers.ForEach(async watcher =>
                {
                    RunWactherRoutine(watcher.PackageId).Wait(10000);
                    RoutineControl.CurrentIteration++;
                    Console.WriteLine("Routine Cicle");
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task RunWactherRoutine(string id)
        {
            try
            {
                await UseCaseOperator.RunWatcherRoutine(id);
            }
            catch (Exception e)
            {
                Console.WriteLine($"--> Package Wacther Routine Exception !!");
                Console.WriteLine($"--> Exception Message: ** {e.Message} **");
                Console.WriteLine($"--> Exception Stack Trace: {e.StackTrace}");
            }
        }

        private void IncrementSearchPagination()
        {
            SearchRequest.Pagination.Offset = SearchRequest.Pagination.Offset + SearchRequest.Pagination.Limit;
        }

        private IPackageWatcherSearch GetInitialSearchReq()
        {
            return new PackageWatcherSearch()
            {
                Pagination = new PaginationIn()
                {
                    Limit = 10,
                    Offset = 0
                }
            };
        }

        private async Task<IPackageWatcherList> SearchWatchers(IPackageWatcherSearch request)
        {
            return await UseCaseOperator.SearchPackageWatchersAsync(request);
        }

        private void TimeOutThread(string message)
        {
            throw new TimeoutException($"--> Package Watcher Routine Timeout Exception: {message}");
        }
    }
}
