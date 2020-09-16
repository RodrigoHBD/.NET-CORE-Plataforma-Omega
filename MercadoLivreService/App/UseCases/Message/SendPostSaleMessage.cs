using MercadoLivreLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreLibrary.Models.Input.Pack;
using MercadoLivreService.App.Models;
using MercadoLivreService.App.UseCases.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class SendPostSaleMessage
    {
        public async Task Execute(long accountId, long orderId, string message)
        {
            try
            {
                await SetAccount(accountId);
                await SetOrder(orderId);
                var req = await GetRequest(message);
                await MercadoLivreLib.Methods.Pack.AddMessage.Execute(req);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private Account Account { get; set; }

        private OrderDetailJson Order { get; set; }

        private async Task SetAccount(long id) => 
            Account = await AccountUseCases.Get.ByMercadoLivreId(id);

        private async Task SetOrder(long id) =>
            Order = await OrderUseCases.GetDetails.Execute(Account.MercadoLivreId, id);

        private async Task<MLLAddMessage> GetRequest(string message)
        {
            return new MLLAddMessage()
            {
                SenderId = Account.MercadoLivreId,
                SenderEmail = Account.Email,
                ReceiverId = Order.buyer.id,
                PackId = GetPackId(),
                MessageText = message,
                Token = await GetToken()
            };
        }

        private async Task<string> GetToken()
        {
            return await TokensUseCases.GetValidAccessToken.ForAccount(Account.MercadoLivreId);
        }

        private long GetPackId()
        {
            return Order.pack_id ?? Order.id;
        }
    }
}
