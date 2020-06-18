var app;

class App {
    IsInitialized = false;
    Controllers = new Controllers();
    Session;
    Computed;
    HttpClient = new HttpClient();

    Initialize() {
        try {
            if (this.IsInitialized) {
                return console.log("App instance is already initialized");
            }

            this.InitializeSession();
            this.InitializeComputed();
            this.InitializeVue();
            this.SetWhenClickedAttribute();
            this.IsInitialized = true;
        }
        catch (erro) {
            throw erro;
        }
    }

    InitializeSession() {
        try {
            this.Controllers.Session.Initialize();
            this.Session = this.Controllers.Session.ExportSession();
        }
        catch (error) {
            throw error;
        }
    }

    InitializeComputed() {
        try {
            this.Controllers.Computed.Initialize();
            this.Computed = this.Controllers.Computed.ExportComputed();
        }
        catch (error) {
            throw error;
        }
    }

    InitializeVue() {
        try {
            this.Controllers.Vue.Initialize();
        }
        catch (error) {
            throw error;
        }
    }

    SetWhenClickedAttribute() {
        var elements = document.getElementsByTagName('*');
        for (var i = 0; i < elements.length; i++) {
            var element = elements[i];
            var hasAtt = element.hasAttribute("whenClicked");

            if (hasAtt) {
                element.addEventListener("click", function (){
                    var code = this.getAttribute('whenclicked');
                    eval(code);
                });
            }

        }
    }
}

app = new App();
app.Initialize();