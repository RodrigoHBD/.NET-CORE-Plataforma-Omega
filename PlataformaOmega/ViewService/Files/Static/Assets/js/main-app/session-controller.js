import CorreiosSession from "/js/main-app/correios/correios.js";
import CommonSession from "/js/main-app/common/common-session.js";
import Controllers from "/js/main-app/controllers.js";

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
    Controllers = application.Controllers;
}
