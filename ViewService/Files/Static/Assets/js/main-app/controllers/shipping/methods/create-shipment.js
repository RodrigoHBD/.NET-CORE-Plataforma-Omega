import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";

export default class CreateShipmentMethod extends ShippingMethod {

    async Run() {
        try {
            var uri = this._GetUri();
            var request = this._Request;
            var response = await application.HttpClient.Post(uri, request);
            return application.HttpClient.Helpers.ResponseHanlder.HandleResponse(response);
        }
        catch (error) {
            throw error;
        }
    }

    constructor(req) {
        super();
        this._Request = req;
    }

    _Request;

    _GetUri() {
        return "api/shipping/new-shipment";
    }

}