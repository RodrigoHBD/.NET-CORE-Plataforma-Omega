using ShippingService.App.Boundries;
using ShippingService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class CheckMarketplaceId
    {
        public static async Task<bool> Execute(string id)
        {
			try
			{
				return await CheckId(id);
			}
			catch (Exception)
			{
				throw;
			}
        }

		private static async Task<bool> CheckId(string id)
		{
			return await PackageDAO.CheckMarketplaceId(id);
		}
    }
}
