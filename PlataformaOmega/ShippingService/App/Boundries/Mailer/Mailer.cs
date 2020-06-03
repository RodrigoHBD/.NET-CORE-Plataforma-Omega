using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShippingService.App.Models;
using ShippingService.App.Boundries.CorreiosTypeAdapters;
using CorreioRastreamentoLibrary;
using ShippingService.Correios;

namespace ShippingService.App.Boundries
{
    public class Mailer
    {
        public static async Task<PackageStatus> GetPackageStatus(string trackingCode)
        {
            try
            {
                //var request = BuscaEventosRequestAdapter.AdaptFromString(trackingCode);
                //var response = await CorreiosRastreamento.PegarDadosDeRastreamento(request);
                return new PackageStatus() 
                {
                    HasBeenDelivered = true,
                    HasBeenPosted = true
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        
    }
}
