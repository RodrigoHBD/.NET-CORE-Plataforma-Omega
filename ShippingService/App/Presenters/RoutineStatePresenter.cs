using ShippingService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Presenters
{
    public class RoutineStatePresenter
    {
        public static GrpcRoutineStates Present(RoutineDates dates, RoutineStates states)
        {
            return new GrpcRoutineStates()
            {
                IsPaused = states.IsPaused,
                IsExecuting = states.IsExecuting,
                IsInitialized = states.IsInitialized,
                LastExecutedAt = dates.LastExecutedAt.ToString(),
                NextExecutionAt = dates.NextExecutionAt.ToString()
            };
        }
    }
}
