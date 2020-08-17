using MercadoLivreService.App.UseCases.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class ShipmentUseCases
    {
        public static GetDetails GetDetails { get; set; } = new GetDetails();
    }
}
