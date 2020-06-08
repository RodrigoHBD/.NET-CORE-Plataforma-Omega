using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Factories
{
    public class ProductFactory
    {
        public static Product MakeProduct()
        {
            return new Product() 
            {

            };
        }
    }
}
