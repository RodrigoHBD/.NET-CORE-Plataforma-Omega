import GetAccountByMercadoLivreIdMethod from "/js/dashboard/view-model/mercado-livre/get_account_data.js";

export default class MercadoLivreMethods {
    async GetAccountData(id) {
        var method = new GetAccountByMercadoLivreIdMethod();
        return await method.Run(id);
    }
}