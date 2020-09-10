export default class GetAccountByMercadoLivreIdMethod {
    async Run() {
        try {
            var uri = this._GetUri();
            var resp = await application.HttpClient.Get(uri);
            return application.HttpClient.Helpers.ResponseHandler.HandleResponse(resp);
        }
        catch (error) {
            throw error;
        }
    }

    constructor(id) {
        this._Id = id;
    }

    _Id;

    _GetUri() {
        return `/api/mercadolivre/account/by-mercado-livre-id?id=${this._Id}`;
    }
}