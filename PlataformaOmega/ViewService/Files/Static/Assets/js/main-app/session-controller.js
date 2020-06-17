class SessionController {
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
    Correios = new CorreiosSession();
}
