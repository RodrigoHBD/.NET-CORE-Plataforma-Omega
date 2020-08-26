using ShippingService.App.Entities.ShipmentDataField;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.ShipmentMethods
{
    public class ValidateNewShipment
    {
        public async Task Execute()
        {
            await ValidateTrackingCode();
            await ValidatePackageId();
        }

        public ValidateNewShipment(Shipment shipment)
        {
            Shipment = shipment;
        }

        private Shipment Shipment { get; }

        private async Task ValidateTrackingCode()
        {
            var code = Shipment.TrackingCode;
            await new ShipmentTrackingCode().ValidateNew(code);

            if (code == null)
            {
                throw new Exception("Codigo de rastreio nao pode ser vazio");
            }
            if(code.Length < 0)
            {
                throw new Exception("Codigo de rastreio muito curto");
            }
        }

        private async Task ValidatePackageId()
        {
            if(Shipment.PackageId != null)
            {
                await PackageEntity.ValidatePackageId(Shipment.PackageId);
            }
        }

    }
}
