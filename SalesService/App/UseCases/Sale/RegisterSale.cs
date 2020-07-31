using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Boundries;
using SalesService.App.Models;

namespace SalesService.App.UseCases
{
    public class RegisterSale
    {
        public async Task<string> Execute(Sale sale)
        {
            try
            {
                return await Boundry.DAO.SaleDAO.RegisterNew(sale);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
