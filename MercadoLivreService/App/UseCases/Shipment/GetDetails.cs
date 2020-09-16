using MercadoLivreLibrary;
using MercadoLivreService.App.UseCases.Tokens;
using MercadoLivreService.MercadoLivre.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases.Shipment
{
    public class GetDetails
    {
        public async Task<ShipmentJson> Execute(long accountId, long shipmentId)
        {
			try
			{
				var token = await TokensUseCases.GetValidAccessToken.ForAccount(accountId);
				return await MercadoLivreLib.Methods.Shipment.GetDetail.Execute(shipmentId, token);
			}
			catch (Exception e)
			{
				throw;
			}
        }

	}
}
