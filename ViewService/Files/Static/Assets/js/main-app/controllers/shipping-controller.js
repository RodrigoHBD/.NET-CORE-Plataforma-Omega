import { Notification } from "/js/main-app/models/models.js";

export default class ShippingController {
    BaseUri = "/api/shipping";

    async RunWatcherRoutine() {
        try {
            var uri = `${this.BaseUri}/run-package-watcher-routine`;
            application.HttpClient.Get(uri);
            this.UpdateWatcherState();
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async UpdateWatcherState() {
        try {
            var uri = `${this.BaseUri}/package-watcher-routine-state`;
            var response = await application.HttpClient.Get(uri);
            var data = application.HttpClient.Helpers.ResponseHandler.HandleResponse(response);
            this.SetWatcherStateFromJson(data);
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    SetWatcherStateFromJson(json) {
        application.Session.Shipping.WatcherState.IsInitialized = json.IsInitialized;
        application.Session.Shipping.WatcherState.IsExecuting = json.IsExecuting;
        application.Session.Shipping.WatcherState.IsPaused = json.IsPaused;
        application.Session.Shipping.WatcherState.LastExecutedAt = json.LastExecutedAt;
        application.Session.Shipping.WatcherState.NextExecutionAt = json.NextExecutionAt;
    }

    async RunPackageWatcherRoutineById(id) {
        try {
            var uri = `${this.BaseUri}/run-package-watcher-routine-by-id?id=${id}`;
            await application.HttpClient.Get(uri);
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async GetNameOfMarketplaceAccount(id, platform) {
        try {
            switch (platform) {
                case "mercado livre":
                    var data = await application.Controllers.MercadoLivre.GetAccountByMercadoLivreId(id);
                    return data.Nickname;
                default:
                    return "sem nome;"
            }
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

}