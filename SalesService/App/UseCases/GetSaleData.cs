using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Boundries;
using SalesService.App.Models.Sale;

namespace SalesService.App.UseCases
{
    public class GetSaleData
    {
        public static async Task<Sale> Execute(string id)
        {
            try
            {
                return await DAO.GetSaleData(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
