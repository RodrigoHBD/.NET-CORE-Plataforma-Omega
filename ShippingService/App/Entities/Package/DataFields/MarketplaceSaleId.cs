using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageDataField
{
    public class MarketplaceSaleId
    {
        public async Task Validate(string id)
        {
			try
			{
				var alreadyRegistered = await PackageDAO.CheckMarketplaceId(id);

				if (alreadyRegistered)
				{
					throw new Exception("Essa venda ja esta registrada na base de dados");
				}
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
