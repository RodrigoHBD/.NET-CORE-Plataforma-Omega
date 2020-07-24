import { Notification } from "/js/main-app/models/models.js";

export default class ShippingController {
    BaseUri = "/api/shipping";

    async RunWatcherRoutine(){
        try {
            var uri = `${this.BaseUri}/run-package-watcher-routine`;
            application.HttpClient.Get(uri);
            this.UpdateWatcherState();
        }
        catch(erro){
            throw erro;
        }
    }

    async UpdateWatcherState(){
        try {
            var uri = `${this.BaseUri}/package-watcher-routine-state`;
            var response = await application.HttpClient.Get(uri);
            this.SetWatcherStateFromJson(response.body);
        }
        catch(erro){
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    SetWatcherStateFromJson(json){
        application.Session.Shipping.WatcherState.IsInitialized = json.IsInitialized;
        application.Session.Shipping.WatcherState.IsExecuting = json.IsExecuting;
        application.Session.Shipping.WatcherState.IsPaused = json.IsPaused;
        application.Session.Shipping.WatcherState.LastExecutedAt = json.LastExecutedAt;
        application.Session.Shipping.WatcherState.NextExecutionAt = json.NextExecutionAt;
    }

    async RunPackageWatcherRoutineById(id){
        try {
            var uri = `${this.BaseUri}/run-package-watcher-routine-by-id?id=${id}`;
            await application.HttpClient.Get(uri);
        }
        catch (erro){
            application.ExceptionHandler.HandleApiCallException(erro);
        }
    }

    HandleException(e){
        try {
            
        } 
        catch (error) {
            throw error;    
        }
    }
}