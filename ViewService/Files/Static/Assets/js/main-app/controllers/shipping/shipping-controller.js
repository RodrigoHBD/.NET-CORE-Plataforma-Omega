import { Notification, SearchFilters } from "/js/main-app/models/common.js";
import Methods from "/js/main-app/controllers/shipping/methods.js"

export default class ShippingController {
    BaseUri = "/api/shipping";

    async CreateShipment() {
        try {
            var data = toolbox.Form.GetFormData("");
            var method = new Methods.Create(data);
            await method.Run();
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async SearchShipments() {
        try {
            var data = toolbox.Form.GetFormData("");
            var method = new Methods.Search(data);
            await method.Run();
        }
        catch (erro) {
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    async RunAutoUpdate() {
        try {
            var uri = `${this.BaseUri}/run-auto-update`;
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
            //var response = await application.HttpClient.Get(uri);

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

    async RunAutoUpdateById(id) {
        try {
            var uri = `${this.BaseUri}/run-auto-update-by-id?id=${id}`;
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
