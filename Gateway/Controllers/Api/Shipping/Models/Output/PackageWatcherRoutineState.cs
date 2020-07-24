using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers.Api.Shipping.Models.Output
{
    public class PackageWatcherRoutineState
    {
        public bool IsInitialized { get; set; } = false;
        public bool IsExecuting { get; set; } = false;
        public bool IsPaused { get; set; } = false;
        public string LastExecutedAt { get; set; } = "";
        public string NextExecutionAt { get; set; } = "";
    }
}
