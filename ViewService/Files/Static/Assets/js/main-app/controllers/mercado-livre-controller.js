export default class MercadoLivreController {
    BaseUri = "/api/mercadolivre";
    AuthCodeExchangeUri = `https://plataforma-omega.brazilsouth.cloudapp.azure.com${this.BaseUri}/process-authcode-exchange`;
    AuthApiUri = "http://auth.mercadolibre.com.ar/authorization?response_type=code"

    async SearchAccounts(){
        
    } 

    GetAccountsSearchFilters(){
        try {

        }
        catch(erro){
            throw erro;
        }
    }

    async BuildAddAccountUri(){
        try {
            var baseUri = this.AuthApiUri;
            var redirectUri = await this.BuildAddAccountRedirectUri();
            var appId = await this.GetAppId();
            var uri =  `${baseUri}&client_id=${appId}&redirect_uri=${redirectUri}`;
            return uri;
        }
        catch(erro){
            throw erro;
        }
    }

    async BuildAddAccountRedirectUri(){
        try {
            var baseRedirectUri = this.AuthCodeExchangeUri;
            return baseRedirectUri;
        }
        catch(erro){
            throw erro;
        }
    }

    async GetAppId(){
        try {
            var uri = `${this.BaseUri}/app-id`;
            var response = await application.HttpClient.Get(uri);
            return response.body;
        }
        catch(erro){
            throw erro;
        }
    }
}