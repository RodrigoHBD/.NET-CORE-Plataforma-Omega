import GetAccountByMercadoLivreIdMethod from "/js/main-app/controllers/mercado-livre/methods/get_account_by_mercado_livre_id.js";

export default class GetAccountData {
    async Run(id){
        var method = new GetAccountByMercadoLivreIdMethod(id);
        var account = await method.Run();
        return account;
    }
}