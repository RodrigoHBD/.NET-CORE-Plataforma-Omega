export default class GetShipmentEvents {
    async Run() {
        var uri = this._GetUri();
        var resp = await application.HttpClient.Get(uri);
        return this._HandleResponse(resp);
    }

    constructor(id) {
        this._Id = id;
    }

    _Id;

    _GetUri() {
        return `/api/shipping/shipment-events?id=${this._Id}`;
    }

    _HandleResponse(resp) {
        return application.HttpClient.Helpers.ResponseHandler.HandleResponse(resp);
    }
}