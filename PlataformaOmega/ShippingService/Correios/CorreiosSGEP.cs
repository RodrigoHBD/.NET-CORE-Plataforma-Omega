using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorreiosSGEPLibrary;

namespace ShippingService.Correios
{
    public class CorreiosSGEP
    {
        private static AtendeClienteClient Client { get; set; }
        
        public static void Initialize()
        {
            try
            {
                Client = new AtendeClienteClient();
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

        public static async Task<consultaCEPResponse> ConsultarCEP(consultaCEP request)
        {
            try
            {
               return await Client.consultaCEPAsync(request);
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public static async Task<solicitaPLPResponse> SolicitarDadosPlp(solicitaPLP request)
        {
            try
            {
                return await Client.solicitaPLPAsync(request);
            }
            catch(System.Exception e)
            {
                throw e;
            }
        }

        public static async Task<fechaPlpResponse> FecharPlp(fechaPlp request)
        {
            try
            {
                return await Client.fechaPlpAsync(request);
            }
            catch (System.Exception e)
            {
                throw e;
            }
        }

    }
}
