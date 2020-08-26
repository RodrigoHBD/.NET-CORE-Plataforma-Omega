using ShippingService.App.Models.Output;
using ShippingService.App.Models.Input;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Methods
    {
        public Register Register { get { return new Register(); } }

        public Delete Delete { get { return new Delete(); } }

        public UpdateSet UpdateSet { get { return new UpdateSet(); } }

        public GetBy GetBy { get { return new GetBy(); } }

        public Count Count { get { return new Count(); } }

        public async Task<ShipmentList> Search(ShipmentSearch req) => await new Search(req).GetResult();
    }
}
