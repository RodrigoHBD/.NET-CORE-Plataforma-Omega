import { Pagination } from "/js/main-app/models/common.js";
//import { HandleConfig } from "/js/http-client/response-handler.js";

export default class MercadoLivreController {
    BaseUri = "/api/mercadolivre";
    AuthCodeExchangeUri = `https://omega.brazilsouth.cloudapp.azure.com${this.BaseUri}/process-authcode-exchange`;
    AuthApiUri = "http://auth.mercadolivre.com.br/authorization?response_type=code"
    AddAccountWindow;

    async SearchAccounts() {
        try {
            var uri = `${this.BaseUri}/search-accounts`;
            var body = this.BuildSearchAccountsRequestBody();
            var response = await application.HttpClient.Post(uri, body);
            this.UpdateAccountsTableFromJsonResponse(response);
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    BuildSearchAccountsRequestBody() {
        try {
            var filters = this.GetAccountsSearchFilters();
            var body = new SearchAccountsReq();
            return body;
        }
        catch (erro) {
            throw erro;
        }
    }

    UpdateAccountsTableFromJsonResponse(json) {
        try {
            var body = json.body;
            var accounts = body.Accounts;
            var pagination = body.Pagination;
            application.Session.MercadoLivre.AccountsTable.Body = accounts;
            application.Session.MercadoLivre.AccountsTable.Pagination = pagination;
        }
        catch (erro) {
            throw erro;
        }
    }

    GetAccountsSearchFilters() {
        try {
            var filters = application.Session.MercadoLivre.AccountsTable.Filters;
        }
        catch (erro) {
            throw erro;
        }
    }

    async BuildAddAccountUri() {
        try {
            var baseUri = this.AuthApiUri;
            var redirectUri = await this.BuildAddAccountRedirectUri();
            var appId = await this.GetAppId();
            var uri = `${baseUri}&client_id=${appId}&redirect_uri=${redirectUri}`;
            return uri;
        }
        catch (erro) {
            throw erro;
        }
    }

    async BuildAddAccountRedirectUri() {
        try {
            var baseRedirectUri = this.AuthCodeExchangeUri;
            return baseRedirectUri;
        }
        catch (erro) {
            throw erro;
        }
    }

    async GetAppId() {
        try {
            var uri = `${this.BaseUri}/app-id`;
            var response = await application.HttpClient.Get(uri);
            return response.body;
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async OpenAddAccountWindow() {
        try {
            var uri = await this.BuildAddAccountUri();
            this.AddAccountWindow = window.open(uri);
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async GetAccountByMercadoLivreId(id) {
        try {
            var uri = `${this.BaseUri}/account/by-mercado-livre-id?id=${id}`;
            var response = await application.HttpClient.Get(uri);
            return application.HttpClient.Helpers.ResponseHandler.HandleResponse(response);
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }
}

class SearchAccountsReq {
    Pagination = new Pagination();
    Name = "";
    Owner = "";
}