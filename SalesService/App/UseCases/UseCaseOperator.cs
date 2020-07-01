using SalesService.App.Models.Input.RegisterNewSale;
using SalesService.App.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Models.Sale;
using SalesService.App.Models.Input;

namespace SalesService.App.UseCases
{
    public class UseCaseOperator
    {
        public static async Task RegisterNewSale(IRegisterNewSaleRequest request)
        {
            try
            {
                var sale = CreateNewSale.Execute(request);
                await SaleEntity.ValidateNewSale(sale);
                await RegisterSale.Execute(sale);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task<Sale> GetSaleDataById(string id)
        {
            try
            {
                await SaleEntity.ValidateSaleId(id);
                return await GetSaleData.Execute(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task UpdateSaleStatusAsync(IUpdateSaleStatusRequest request)
        {
            try
            {
                await SaleEntity.ValidateSaleId(request.Id);
                SaleEntity.ValidateSaleStatus(request.Status);
                await UpdateSaleStatus.Execute(request.Id, request.Status);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

      
        
    }
}
