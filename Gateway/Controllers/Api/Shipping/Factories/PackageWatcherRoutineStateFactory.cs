using Gateway.Controllers.Api.Shipping.Models.Output;
using Gateway.gRPC.Client.ShippingClientProto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Factories
{
    public class PackageWatcherRoutineStateFactory
    {
        public static PackageWatcherRoutineState Make(GrpcRoutineStates states)
        {
            return new PackageWatcherRoutineState()
            {
                IsInitialized = states.IsInitialized,
                IsExecuting = states.IsExecuting,
                IsPaused = states.IsPaused,
                LastExecutedAt = states.LastExecutedAt,
                NextExecutionAt = states.NextExecutionAt
            };
        }

        public static string MakeSerialized(GrpcRoutineStates states)
        {
            try
            {
                var model = Make(states);
                return JsonSerializer.Serialize(model);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
