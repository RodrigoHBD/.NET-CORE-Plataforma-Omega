using ShippingService.App.Boundries;
using ShippingService.App.Models;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class RunAutoUpdate
    {
        public async Task Execute()
        {
            try
            {
                Search = GetInitialSeach();
                var results = await ShipmentDAO.Methods.Search(Search);
                var total = results.Pagination.Total;
                await SetShipments();

                for (; Search.Pagination.Offset < total; IncrementSearch(), await SetShipments())
                {
                    Shipments.ForEach(async shipment => { 
                        await Update(shipment); });
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //return;
            }
        }

        private List<Shipment> Shipments { get; set; } = new List<Shipment>();

        private ShipmentSearch Search { get; set; } = new ShipmentSearch();

        private async Task SetShipments()
        {
            Shipments = (await ShipmentDAO.Methods.Search(Search)).Data;
        }

        private void IncrementSearch()
        {
            Search.Pagination.Offset = Search.Pagination.Offset + Search.Pagination.Limit;
            Search.Pagination.Limit = Search.Pagination.Limit;
        }

        private async Task Update(Shipment shipment)
        {
            await ShipmentUseCases.UpdateShipmentWithBoundry(shipment);
        }

        private ShipmentSearch GetInitialSeach()
        {
            return new ShipmentSearch()
            {
                AutoUpdate = new BoolSearchFilter()
                {
                    IsSet = true,
                    Value = true
                },
                Pagination = GetInitialPagination()
            };
        }

        private PaginationIn GetInitialPagination()
        {
            return new PaginationIn()
            {
                Offset = 0,
                Limit = 10
            };
        }

    }
}
