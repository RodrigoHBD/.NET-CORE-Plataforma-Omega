using MongoDB.Driver;
using ShippingService.App.Models;
using ShippingService.App.Models.Output;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models.ShipmentEvents;

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

        private void SetAutoUpdateFilter()
        {
            if (Request.AutoUpdate.IsSet)
            {
                var value = Request.AutoUpdate.Value;
                var filter = FilterBuilder.Where(shipment => shipment.AutoUpdate == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetBoundMarketplaceFilter()
        {
            if (Request.BoundMarketplace.IsSet)
            {
                var value = Request.BoundMarketplace.Value;
                var filter = FilterBuilder.Where(shipment => shipment.MarketplaceData.BoundMarketplace == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetDynamicStringFilter()
        {
            if (Request.DynamicString.IsSet)
            {
                var value = Request.DynamicString.Value;
                var filter = FilterBuilder.Where(shipment => shipment.TrackingCode == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetPostedFilter()
        {
            if (Request.IsPosted.IsSet)
            {
                var value = Request.IsPosted.Value;
                var filter = FilterBuilder.Where(shipment => shipment.PostedEvent.IsPosted == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetBeingTransportedFilter()
        {
            if (Request.IsBeingTransported.IsSet)
            {
                
            }
        }

        private void SetDeliveredFilter()
        {
            if (Request.IsDelivered.IsSet)
            {
                var value = Request.IsDelivered.Value;
                var filter = FilterBuilder.Where(shipment => shipment.DeliveredEvent.IsDelivered == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetDeliveredToDestinationFilter()
        {
            if (Request.IsDeliveredToDestination.IsSet)
            {
                var value = Request.IsDeliveredToDestination.Value;
                var filter = FilterBuilder.Where(shipment => shipment.DeliveredEvent.IsDeliveredToDestination == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetAwaitingForPickUpFilter()
        {
            if (Request.IsAwaitingForPickUp.IsSet)
            {
                var value = Request.IsAwaitingForPickUp.Value;
                var filter = FilterBuilder.Where(shipment => shipment.AwaitingForPickUpEvent.IsSet == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetRejectedFilter()
        {
            if (Request.IsRejected.IsSet)
            {
                var value = Request.IsAwaitingForPickUp.Value;
                var filter = FilterBuilder.Where(shipment => shipment.RejectedEvent.IsRejected == value);
                Filter = FilterBuilder.And(Filter, filter);
            }
        }

        private void SetFilter()
        {
            SetBoundMarketplaceFilter();
            SetDynamicStringFilter();
            SetPostedFilter();
            SetDeliveredFilter();
            SetDeliveredToDestinationFilter();
            SetAwaitingForPickUpFilter();
            SetRejectedFilter();
            //SetBeingTransportedFilter();
            SetAutoUpdateFilter();
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
