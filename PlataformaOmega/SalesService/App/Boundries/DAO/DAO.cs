using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models.Sale;

namespace SalesService.App.Boundries
{
    public class DAO
    {
        public static async Task<Sale> GetSaleData(string id)
        {
            try
            {
                return new Sale();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<bool> CheckIdSaleExist(string id)
        {
            try
            {
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
