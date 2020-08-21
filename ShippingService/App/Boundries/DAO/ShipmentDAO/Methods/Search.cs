using MongoDB.Driver;
using ShippingService.App.Models;
using ShippingService.App.Models.Output;
using ShippingService.App.Models.ShipmentSearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Boundries.ShipmentDAOMethods
{
    public class Search : ShipmentDAOMethod
    {
        public async Task<ShipmentList> GetResult()
        {
            try
            {
                return new ShipmentList()
                {
                    Data = await GetSearchData(),
                    Pagination = await GetPagination()
                };
            }
            catch (Exception)
            {
                throw;
            }

        }

        public Search(ShipmentSearch request)
        {
            Request = request;
            SetFilter();
        }

        private ShipmentSearch Request { get; }

        private FilterDefinition<Shipment> Filter { get; set; } = FilterBuilder.Empty;

        private void SetBoundMarketplaceFilter()
        {
            if (Request.BoundMarketplace.IsSet)
            {
                var value = Request.BoundMarketplace.Value;
                var filter = FilterBuilder.Where(shipment => shipment.MarketplaceData.BoundMarketplace == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetDynamicStringFilter()
        {
            if (Request.DynamicString.IsSet)
            {
                var value = Request.DynamicString.Value;
                var filter = FilterBuilder.Where(shipment => shipment.TrackingCode == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetPostedFilter()
        {
            if (Request.IsPosted.IsSet)
            {
                var value = Request.IsPosted.Value;
                var filter = FilterBuilder.Where(shipment => shipment.PostedEvent.IsPosted == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetBeingTransportedFilter()
        {
            if (Request.IsBeingTransported.IsSet)
            {
                var value = Request.IsBeingTransported.Value;
                var filter = FilterBuilder.Where(shipment => shipment.ForwardingEvents.Last().PackageHasArrived == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetDeliveredFilter()
        {
            if (Request.IsDelivered.IsSet)
            {
                var value = Request.IsDelivered.Value;
                var filter = FilterBuilder.Where(shipment => shipment.DeliveredEvent.IsDelivered == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetAwaitingForPickUpFilter()
        {
            if (Request.IsAwaitingForPickUp.IsSet)
            {
                var value = Request.IsAwaitingForPickUp.Value;
                var filter = FilterBuilder.Where(shipment => shipment.AwaitingForPickUpEvent.IsSet == value);
                Filter = FilterBuilder.Or(Filter, filter);
            }
        }

        private void SetFilter()
        {
            SetBoundMarketplaceFilter();
            SetDynamicStringFilter();
            SetPostedFilter();
            SetDeliveredFilter();
            SetAwaitingForPickUpFilter();
            SetBeingTransportedFilter();
        }

        private async Task<List<Shipment>> GetSearchData()
        {
            var pagination = Request.Pagination;
            return Collections.Shipments.Find(Filter).Limit(pagination.Limit).Skip(pagination.Offset).ToList();
        }

        private async Task<PaginationOut> GetPagination()
        {
            return new PaginationOut()
            {
                Offset = Request.Pagination.Offset,
                Limit = Request.Pagination.Limit,
                Total = await ShipmentDAO.Methods.Count.UsingFilter(Filter)
            };
        }
    }
}
