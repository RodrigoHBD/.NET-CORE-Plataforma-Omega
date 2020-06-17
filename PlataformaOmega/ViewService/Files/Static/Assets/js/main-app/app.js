var app;

class App {
    IsInitialized = false;
    VueController;
    SessionController;
    Session;
    HttpClient = new HttpClient();

    Initialize(){
        try{
            if(this.IsInitialized){
                return console.log("App instance is already initialized");
            }
            
            this.InitializeSession();
            this.InitializeVue();
            this.IsInitialized = true;
        }
        catch(erro){
            throw erro;
        }
    }

    InitializeSession(){
        try {
            this.SessionController = new SessionController();
            this.SessionController.Initialize();
            this.Session = this.SessionController.ExportSession();
        }
        catch(error){
            throw error;
        }
    }

    InitializeVue(){
        try {
            this.VueController = new VueController();
            this.VueController.Initialize();
        } 
        catch (error) {
            throw error;
        }
    }
}

window.onload = () => {
    app = new App();
    app.Initialize();
};