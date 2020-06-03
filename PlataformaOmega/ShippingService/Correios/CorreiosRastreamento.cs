using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorreioRastreamentoLibrary;
using CorreiosSGEPLibrary;

namespace ShippingService.Correios
{
    public class CorreiosRastreamento
    {
        private static ServiceClient Client { get; set; } = new CorreioRastreamentoLibrary.ServiceClient(ServiceClient.EndpointConfiguration.ServicePort);

        public static async Task<CorreioRastreamentoLibrary.objeto> PegarDadosDeRastreamento(buscaEventosListaRequest request)
        {
            try
            {
                var conn = new CorreioRastreamentoLibrary.ServiceClient(ServiceClient.EndpointConfiguration.ServicePort);
                await conn.OpenAsync();
                var conn2 = new CorreiosSGEPLibrary.AtendeClienteClient();
              
                var response = await conn.buscaEventosListaAsync(request);
                
                return response.@return.objeto.First();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }
    }
}
