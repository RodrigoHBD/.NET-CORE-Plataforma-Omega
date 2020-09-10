export default class RunAutoUpdateMethod {
    async Run() {
        try {
            var uri = this._GetUri();
            var resp = await application.HttpClient.Get(uri);
            application.HttpClient.Helpers.ResponseHandler.HandleResponse(resp);
        }
        catch (error) {
            throw error;
        }
    }

    async RunById(id) {
        try {
            var uri = this._GetUriForRunningById(id);
            var resp = await application.HttpClient.Get(uri);
            application.HttpClient.Helpers.ResponseHandler.HandleResponse(resp);
        }
        catch (error) {
            throw error;
        }
    }

    _GetUri() {
        return "/api/shipping/run-auto-update";
    }

    _GetUriForRunningById(id) {
        return `/api/shipping/run-auto-update-by-id?id=${id}`;
    }
}