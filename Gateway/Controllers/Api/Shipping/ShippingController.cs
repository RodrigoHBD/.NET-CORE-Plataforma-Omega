using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gateway.Controllers.Api.Shipping.Factories;
using Gateway.Controllers.Api.Shipping.Models.Input;
using Gateway.Controllers.Api.Shipping.Presenter;
using Gateway.Controllers.Shipping.Input;
using Gateway.gRPC.Client;
using Gateway.gRPC.Client.ShippingClientProto;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingController : ControllerBase
    {
        [Route("new-shipment")]
        [HttpPost]
        public async Task<IActionResult> CreateShipment(NewShipment json)
        {
            try
            {
                var req = GrpcNewShipmentRequestFactory.GetFrom(json);
                await ShippingClient.CreateShipment(req);
                return EmpityAnswer;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("shipment")]
        [HttpGet]
        public async Task<IActionResult> GetShipment(string id)
        {
            try
            {
                var req = new GrpcString() { Value = id };
                var shipment = await ShippingClient.GetShipmentById(req);

                return new ContentResult()
                {
                    Content = ShipmentPresenter.PresentSerialized(shipment),
                    ContentType = "application/json"
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("shipment-events")]
        [HttpGet]
        public async Task<IActionResult> GetShipmentEvents(string id)
        {
            try
            {
                var req = new GrpcString() { Value = id };
                var events = await ShippingClient.GetShipmentEvents(req);

                return new ContentResult()
                {
                    Content = ShipmentEventsPresenter.PresentSerialized(events),
                    ContentType = "application/json"
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("search-shipments")]
        [HttpPost]
        public async Task<IActionResult> SearchShipments(ShipmentSearch search)
        {
            try
            {
                var req = GrpcShipmentSearchRequestFactory.GetFrom(search);
                var resp = await ShippingClient.SearchShipments(req);
                return new ContentResult()
                {
                    Content = ShipmentListPresenter.GetSerializedFrom(resp),
                    ContentType = "application/json"
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [Route("shipment")]
        [HttpDelete]
        public async Task DeleteShipment(string id)
        {
            try
            {
                var req = GrpcStringFactory.From(id);
                await ShippingClient.DeleteShipment(req);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("run-auto-update")]
        public async Task RunAutoUpdate()
        {
            try
            {
                var req = new GrpcVoid();
                await ShippingClient.RunAutoUpdate(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("run-auto-update-by-id")]
        public async Task RunAutoUpdateById(string id)
        {
            try
            {
                var req = GrpcStringFactory.From(id);
                await ShippingClient.RunAutoUpdateById(req);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("is-marketplace-sale-id-registered")]
        public async Task<IActionResult> GetIsMarketplaceSaleIdRegistered(string id)
        {
            try
            {
                var req = GrpcStringFactory.From(id);
                var resp = await ShippingClient.GetIsMarketplaceSaleIdRegistered(req);
                return new ContentResult()
                {
                    Content = $"{{ 'IsRegistered': {resp.Value} }}",
                    ContentType = "application/json"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("package-watcher-routine-state")]
        public async Task<IActionResult> GetPackageWatcherRoutineState()
        {
            try
            {
                var req = new GrpcVoid();
                return new ContentResult();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private ContentResult EmpityAnswer = new ContentResult()
        {
            ContentType = "application/json",
            Content = ""
        };

    }
}
