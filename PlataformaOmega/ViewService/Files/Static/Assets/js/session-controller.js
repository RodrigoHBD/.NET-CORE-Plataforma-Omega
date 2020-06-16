class SessionController {
      Initialize(){

      }
      ExportSession(){
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
    Correios = new CorreiosSession()
}

class CorreiosSession {
    CachedPackage = new Package();
}