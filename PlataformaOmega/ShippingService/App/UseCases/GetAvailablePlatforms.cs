using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetAvailablePlatforms
    {
        public static List<Platform> Execute()
        {
            return new List<Platform>()
            {
                new Platform(){ Name = "Mercado Livre" }
            };
        }
    }
    //pul
}
