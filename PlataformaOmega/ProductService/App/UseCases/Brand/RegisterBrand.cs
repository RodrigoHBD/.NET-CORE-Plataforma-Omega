using ProductService.App.Boundries;
using ProductService.App.Boundries.DAO;
using ProductService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.UseCases
{
    public class RegisterBrand
    {
        public static async Task Execute(Brand brand)
        {
            try
            {
                await BrandDAO.RegisterBrand(brand);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
