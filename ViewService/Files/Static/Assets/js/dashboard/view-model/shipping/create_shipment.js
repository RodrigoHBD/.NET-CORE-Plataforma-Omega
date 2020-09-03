import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import { NewShipmentRequest, NewShipmentPackageData } from "/js/main-app/models/shipping/shipping-models.js";
import CreateShipmentMethod from "/js/main-app/controllers/shipping/methods/create-shipment.js";

export default class CreateShipment extends BaseMethod {
    async Run() {
        try {
            var request = this._GetRequest();
            var method = new CreateShipmentMethod(request);
            await method.Run();
            this._ShowSucessfullSpan();
            this._ClearForm();
        }
        catch (error) {
            this._HandleError(error);
        }
    }

    constructor() {
        super();
        this._FormData = toolbox.Form.GetFormData("new-shipment-form");
    }

    _FormData;

    _ClearForm() {
        toolbox.Form.Clear("new-shipment-form");
    }

    _ShowSucessfullSpan() {

    }

    _HandleError(e) {
        console.log("error creating shipment =>", error);
        this._ClearForm();
    }

    _GetRequest() {
        var req = new NewShipmentRequest();
        var data = this._FormData;
        req.TrackingCode = data.TrackingCode;
        req.BoundMarketplace = data.BoundMarketplace;
        req.MarketpalceAccountId = data.MarketpalceAccountId;
        req.MarketpalceSaleId = data.MarketpalceSaleId;
        req.SetAutUpdate = true;
        req.SetCreatedManually = true;
        req.ShippingService = data.ShippingService;
        req.Package = this._GetPackageData();
        return req;
    }

    _GetPackageData() {
        return {};
    }

}