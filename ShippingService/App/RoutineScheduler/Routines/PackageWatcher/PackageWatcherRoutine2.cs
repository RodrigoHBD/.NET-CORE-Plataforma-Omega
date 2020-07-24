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

        public string Name { get; set; }

        public int CallbackIntervalInMilliseconds { get; set; }

        private bool ShouldExecute
        {
            get
            {
                if(!States.IsPaused && !States.IsExecuting)
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

        public RoutineStates States { get; set; } = new RoutineStates();

        public RoutineDates Dates { get; set; } = new RoutineDates();

        public PackageWatcherRoutine2()
        {
            Name = "Package Watcher";
            CallbackIntervalInMilliseconds = 14400000;   
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
            States.IsInitialized = true;
        }

        public async Task End()
        {
            _RoutineTimer.Dispose();
            States.IsInitialized = false;
            States.IsPaused = false;
            States.IsExecuting = false;
        }

        public async Task Pause()
        {
            States.IsPaused = true;
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
            States.IsPaused = false;
            //await Run();
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
                StartCicle();
                InitializeRoutine();
                
                while (RoutineControl.WathersTotalNumber > RoutineControl.CurrentIteration)
                {
                    await RunSearch();
                    IncrementSearchPagination();
                }

                FinishCicle();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void StartCicle()
        {
            CicleStartedUpdateDates();
            CicleStartedUpdateStates();
        }

        private void FinishCicle()
        {
            CicleFinishedUpdateDates();
            CicleFinishedUpdateStates();
        }

        private void CicleStartedUpdateStates()
        {
            States.IsExecuting = true;
        }

        private void CicleStartedUpdateDates()
        {
            Dates.NextExecutionAt = DateTime.Now.AddMilliseconds(CallbackIntervalInMilliseconds);
        }

        private void CicleFinishedUpdateStates()
        {
            States.IsExecuting = false;
        }

        private void CicleFinishedUpdateDates()
        {
            Dates.LastExecutedAt = DateTime.Now;
        }

        private async Task RunSearch()
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
