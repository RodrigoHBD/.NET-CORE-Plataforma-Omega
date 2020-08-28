import ShippingSession from "/js/main-app/models/session/shipping-session.js";
import CommonSession from "/js/main-app/models/session/common-session.js";
import MercadoLivreSession from "/js/main-app/models/session/mercado-livre-session.js";
import Controllers from "/js/main-app/controllers/controllers.js";

export default class Session {
    Common = new CommonSession();
    Shipping = new ShippingSession();
    MercadoLivre = new MercadoLivreSession();

    Controllers = new Controllers();
}