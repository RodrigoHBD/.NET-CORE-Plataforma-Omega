using HttpClientLibrary;
using MercadoLivreLibrary.Models;
using MercadoLivreLibrary.Models.Input.Pack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreLibrary.Methods.Pack
{
    public class AddMessage : MercadoLivreMethod
    {
        public async Task Execute(MLLAddMessage message)
        {
            try
            {
                var req = GetRequest(message);
                await HttpClientLib.Post(req);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        private string GetUri(MLLAddMessage message)
        {
            return $"{BaseUri}/messages/packs/{message.PackId}/sellers/{message.SenderId}";
        }

        private List<UriParam> GetParams(MLLAddMessage message)
        {
            return new List<UriParam>()
            {
                new UriParam(){ Name = "access_token", Data = message.Token }
            };
        }

        private AddMessageJson GetData(MLLAddMessage message)
        {
            return new AddMessageJson()
            {
                text = message.MessageText,
                from = new AddMessageSenderJson()
                {
                    user_id = message.SenderId.ToString(),
                    email = message.SenderEmail
                },
                to = new AddMessageReceiverJson()
                {
                    user_id = message.ReceiverId.ToString()
                }
            };
        }

        private PostRequest GetRequest(MLLAddMessage message)
        {
            return new PostRequest()
            {
                Uri = GetUri(message),
                Params = GetParams(message),
                Data = GetData(message)
            };
        }
    }
}
