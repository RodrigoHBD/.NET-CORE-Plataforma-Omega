using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App
{
    interface IRoutine
    {
        public int CallbackIntervalInMilliseconds { get; }
        public void Callback(Object data);
    }
}
