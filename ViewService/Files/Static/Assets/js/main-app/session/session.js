import CorreiosSession from "/js/main-app/session/correios.js";
import ShippingSession from "/js/main-app/session/shipping.js";
import CommonSession from "/js/main-app/session/common.js";
import MercadoLivreSession from "/js/main-app/session/mercado-livre.js";
import Controllers from "/js/main-app/controllers/controllers.js";

export default class Session {
    Common = new CommonSession();
    Correios = new CorreiosSession();
    Shipping = new ShippingSession();
    Controllers = new Controllers();
    MercadoLivre = new MercadoLivreSession();

    Methods = {
        ExecuteWarningCallback: function () { console.log("cu") }
    };
}