using SalesService.App.Models.Input.RegisterNewSale;
using SalesService.App.Models.Sale;
using SalesService.gRPC.Server.Protos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.TypeAdapters
{
    public class GrpcRegisterSaleRequestAdapter
    {
        public static IRegisterNewSaleRequest Adapt(GrpcRegisteSaleRequest grpcRequest)
        {
            try
            {
                return new RegisterNewSaleRequest()
                {
                    ProductId = grpcRequest.ProductId,
                    TotalValue = (decimal)grpcRequest.TotalSaleValue,
                    QuantitySold = grpcRequest.QuantitySold,
                    Plataform = MatchPlataform(grpcRequest.Plataform)
                };

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static SalePlataform MatchPlataform(string input)
        {
            try
            {
                SalePlataform plataform = SalePlataform.Invalid;

                if(input == "mercado-livre")
                {
                    plataform = SalePlataform.MercadoLivre;
                }
                if(input == "b2w")
                {
                    plataform = SalePlataform.B2W;
                }
                if (input == "americanas")
                {
                    plataform = SalePlataform.Americanas;
                }
                if (input == "leroy-merlin")
                {
                    plataform = SalePlataform.LeroyMerlin;
                }

                return plataform;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }

    public class RegisterNewSaleRequest : IRegisterNewSaleRequest
    {
        public string ProductId { get; set; }
        public decimal TotalValue { get; set; }
        public int QuantitySold { get; set; }
        public SalePlataform Plataform { get; set; }
    }

}
