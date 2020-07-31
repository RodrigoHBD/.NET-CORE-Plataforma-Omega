using MercadoLivreService.App.Models;
using MercadoLivreService.MercadoLivreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class BuildAccountUpdate
    {
        public static AccountUpdate BuildFromBoundryData(AccountSelfDataJson data)
        {
			try
			{
				return new AccountUpdate()
				{
					Email = new StringFieldUpdate() 
					{
						MustUpdate = true,
						Value = data.email
					},
					Nickname = new StringFieldUpdate()
					{
						MustUpdate = true,
						Value = data.nickname
					}
				};
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
