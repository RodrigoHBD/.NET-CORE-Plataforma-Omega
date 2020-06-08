using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Factories
{
    public class LocationFactory
    {
        public static Location MakeDefaultLocation()
        {
            return new Location()
            {
                IsSet = false,
                State = "Não especificado",
                City = "Não especificado",
                Cep = "Não especificado",
                Neighborhood = "Não especificado",
                StreetName = "Não especificado"
            };
        }

        public static Location MakeLocationForPackageInMovement()
        {
            return new Location()
            {
                IsSet = false,
                State = "Entrega está sendo transportada",
                City = "Entrega está sendo transportada",
                Cep = "Entrega está sendo transportada",
                Neighborhood = "Entrega está sendo transportada",
                StreetName = "Entrega está sendo transportada"
            };
        }

    }
}
