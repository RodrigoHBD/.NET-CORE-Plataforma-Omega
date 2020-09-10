import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import { NotificationSpan } from "/js/dashboard/models/notification_span.js";
import { NewShipmentRequest, NewShipmentPackageData } from "/js/main-app/models/shipping/shipping-models.js";
import CreateShipmentMethod from "/js/main-app/controllers/shipping/methods/create-shipment.js";
import SetNewShipmentForm from "/js/dashboard/view-model/shipping/set_new_shipment_form.js"

export default class CreateShipment extends BaseMethod {
    async Run() {
        try {
            this._FormSetter.SetLoadingOn();
            var request = this._GetRequest();
            var method = new CreateShipmentMethod(request);
            await method.Run();
            this._ShowSucessfullSpan();
            this._ClearForm();
        }
        catch (error) {
            this._HandleError(error);
        }
        finally {
            this._FormSetter.SetLoadingOff();
        }
    }

    constructor() {
        super();
        this._FormData = toolbox.Form.GetFormData("new-shipment-form");
    }

    _FormData;

    _FormSetter = new SetNewShipmentForm();

    _ClearForm() {
        toolbox.Form.Clear("new-shipment-form");
    }

    _ShowSucessfullSpan() {
        var span = new NotificationSpan();
        span.Title = "Envio Criado!";
        span.Lifetime = 2500;
        vue_app.Methods.NotificationSpan.Notify(span);
    }

    _HandleError(e) {
        console.log("error creating shipment =>", e);
        var span = new NotificationSpan();
        span.Title = "Erro na criação do Envio!";
        span.Text = e.message;
        span.Lifetime = 5000;
        vue_app.Methods.NotificationSpan.Notify(span);
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