using ShippingService.App.Boundries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageDataField
{
    public class TrackingCode
    {
        public async Task Valdiate(string code)
        {
			try
			{
				var isNotNull = code != null;
				var alreadyRegisted = await PackageDAO.CheckTrackingCode(code);

				if (!isNotNull)
				{
					throw new Exception("Codigo de rastreio invalido");
				}
				if (alreadyRegisted)
				{
					throw new Exception("Esse codigo de rastreio ja esta registrado na base de dados");
				}
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
