using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Methods
    {
        public Register Register { get { return new Register(); } }
        public UpdateSet UpdateSet { get { return new UpdateSet(); } }
        public GetBy GetBy { get { return new GetBy(); } }
    }
}
