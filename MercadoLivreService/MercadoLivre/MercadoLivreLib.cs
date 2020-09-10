using Google.Protobuf.WellKnownTypes;
using MercadoLivreService.App;
using MercadoLivreService.App.UseCases;
using MercadoLivreService.HttpClientLibrary;
using MercadoLivreService.HttpClientLibrary.Helpers;
using MercadoLivreService.MercadoLivre;
using MercadoLivreService.MercadoLivre.Methods;
using MercadoLivreService.MercadoLivreModels;
using MercadoLivreService.MercadoLivreModels.In;
using MercadoLivreService.MercadoLivreModels.Out;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MercadoLivreService
{
    public class MercadoLivreLib
    {
        private static string BaseUri { get; } = "https://api.mercadolibre.com";

        private static string AuthCodeUri { get { return $"{BaseUri}/oauth/token?grant_type=authorization_code"; } }

        private static string RefreshTokenUri { get { return $"{BaseUri}/oauth/token?grant_type=refresh_token"; } }

        public static MercadoLivreAppCredentials Credentials { get { return AppCredentials.GetInstance(); } }

        public static MercadoLivreMethods Methods { get; private set; } = new MercadoLivreMethods();

        public static ResponseHandler ResponseHandler { get; private set; } = new ResponseHandler();

        public static async Task<AccessTokensJson> ExchangeCodeForTokens(string code)
        {
            try
            {
                await Methods.Tokens.ExchangeAuthCodeForTokens.Execute(new MercadoLivre.Models.In.ExchangeAuthCodeCall());
                var credentials = Credentials;
                var uri = $"{AuthCodeUri}&client_id={credentials.AppId}&client_secret={credentials.AppToken}&code={code}&redirect_uri=https://plataforma-omega.brazilsouth.cloudapp.azure.com/api/mercadolivre/process-authcode-exchange";
                return await HttpClientLibrary.HttpClient.Post<AccessTokensJson>(uri, null);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public static async Task<AccessTokensJson> RefreshTokens(string refresh_token)
        {
            try
            {
                try
                {
                    var credentials = Credentials;
                    var uri = $"{RefreshTokenUri}&client_id={credentials.AppId}&client_secret={credentials.AppToken}&refresh_token={refresh_token}";
                    return await HttpClientLibrary.HttpClient.Post<AccessTokensJson>(uri, null);
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> GetOrderDetails(string id, string accessToken)
        {
            try
            {
                var uri = $"{BaseUri}/orders/{id}?access_token={accessToken}";
                var response = await HttpClientLibrary.HttpClient.Post(uri, null);
                return ResponseHandler.HandleApiResponse<OrderDetailsJson>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> GetAccountDetails()
        {
            try
            {
                await Methods.Account.GetAccountDetails.Execute(new ApiCall());
                return new ApiCallResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> SearchRecentOrdersAsync(SearchOrdersApiCall call)
        {
            try
            {
                var uri = $"{BaseUri}/orders/search/recent?seller={call.SellerId}&access_token={call.AccessToken}";
                var response = await HttpClientLibrary.HttpClient.Get(uri);
                return ResponseHandler.HandleApiResponse<OrderSearchJson>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<ApiCallResponse> GetUserData(string accessToken)
        {
            try
            {
                var uri = $"{BaseUri}/users/me?access_token={accessToken}";
                var response = await HttpClientLibrary.HttpClient.Get(uri);
                return ResponseHandler.HandleApiResponse<AccountSelfDataJson>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
