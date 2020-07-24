import CorreiosSession from "/js/main-app/session/correios.js";
import ShippingSession from "/js/main-app/session/shipping.js";
import CommonSession from "/js/main-app/session/common.js";
import Controllers from "/js/main-app/controllers/controllers.js";

export default class SessionController {
    Initialize() {
        try {

        }
        catch (error) {
            throw error;
        }
    }
    ExportSession() {
        try {
            var session = new Session();
            return session;
        }
        catch (error) {
            throw error;
        }
    }
}

class Session {
    Common = new CommonSession();
    Correios = new CorreiosSession();
    Shipping = new ShippingSession();
    Controllers = new Controllers();

    Methods = {
        ExecuteWarningCallback: function () { console.log("cu") }
    };
}
