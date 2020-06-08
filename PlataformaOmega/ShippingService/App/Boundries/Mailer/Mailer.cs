using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models;
using CorreioRastreamentoLibrary;
using ShippingService.Correios;
using ShippingService.App.Boundries.MailerTypeAdapters;
using ShippingService.App.Models.MailerService.PackageData;

namespace ShippingService.App.Boundries
{
    public class Mailer
    {
        public static async Task<MailerServicePackageData> GetPackageData(string trackingCode)
        {
            try
            {
                var response = await CorreiosRastreamento.PegarDadosDeRastreamento(trackingCode);
                return SroJsonResponseAdapter.AdaptToPackageStatus(response);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
