import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";

export default class CreateShipment extends ShippingMethod {

    async Run() {
        try {
            var uri = this._GetUri();
            var request = this._GetRequest();
            var response = await application.HttpClient.Post(uri, request);
            var json = await application.HttpClient.Helpers.ResponseHanlder.HandleResponse(response);
            console.log(json);
        }
        catch (error) {
            throw error;
        }
    }

    constructor(form_data) {
        this._FormData = form_data;
    }

    _FormData;

    _GetUri() {
        return "api/shipping/new-shipment";
    }

    _GetRequest() {
        var data = this._FormData;
        var req = new CreateShipmentRequest();
        req.TrackingCode = data.TrackingCode;
        req.BoundMarketplace = data.BoundMarketplace;
        req.MarketpalceAccountId = data.MarketpalceAccountId;
        req.MarketpalceSaleId = data.MarketpalceSaleId;
        req.SetAutUpdate = true;
        req.SetCreatedManually = true;
        req.ShippingService = data.ShippingService;
        req.Package = this._GetPackageData();
    }

    _GetPackageData() {
        return {
            weight: 1
        };
    }

}

class CreateShipmentRequest {
    TrackingCode = "";
    BoundMarketplace = "";
    MarketpalceAccountId = "";
    MarketpalceSaleId = "";
    ShippingService = "";
    SetAutoUpdate = false;
    SetCreatedManually = false;
    Package = new PackageData();
}

class PackageData {
    Name = "";
    WeightInGrams = 0;
    WidthInMm = 0;
    LengthInMm = 0;
    HeightInMm = 0;
    Content = new Array();
}
