using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesService.App.Boundries;
using SalesService.App.Models.Sale;
using SalesService.App.CustomExceptions;
using SalesService.App.Entities.SaleDataFields;
using SalesService.App.Entities.DataFields;

namespace SalesService.App.Entities
{
    public class SaleEntity
    {
        public static async Task ValidateNewSale(Sale sale)
        {
            try
            {
                await ValidateDataFields(sale);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static async Task ValidateSaleId(string id)
        {
            try
            {
                var saleExist = await DAO.CheckIdSaleExist(id);

                if (!saleExist)
                {
                    throw new ValidationException("Id", "Id de venda inexistente");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void ValidateSaleStatus(SaleStatus status)
        {
            try
            {
                Status.Valdiate(status);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task ValidateDataFields(Sale sale)
        {
            try
            {
                await ProductId.Validate(sale.ProductId);
                Status.Valdiate(sale.Status);
                Inventory.Validate(sale.Inventory);
                Plataform.Validate(sale.Plataform);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
