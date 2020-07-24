import Controllers from "/js/main-app/controllers/controllers.js";
import ExceptionHandler from "/js/main-app/exception-handler.js";

export default class App {
    IsInitialized = false;
    Controllers;
    Session;
    Computed;
    HttpClient = new HttpClient();
    ExceptionHandler = new ExceptionHandler();

    Initialize() {
        try {
            console.log("initializeing application instance...")
            if (this.IsInitialized) {
                return console.log("App instance is already initialized");
            }
            this.InitialzieControllers();
            this.InitializeSession();
            //this.InitializeComputed();
            this.InitializeVue();
            //this.SetWhenClickedAttribute();
            this.IsInitialized = true;
        }
        catch (erro) {
            throw erro;
        }
    }

    InitialzieControllers(){
        try {
            this.Controllers = new Controllers();
        }
        catch (error) {
            throw error;
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
            var hasAlreadyBeenSet = element.hasAttribute("whenClickedHasBeenSet")

            if (hasAtt && !hasAlreadyBeenSet) {
                element.addEventListener("click", function () {
                    element.setAttribute("whenClickedHasBeenSet", true);
                    var code = this.getAttribute('whenClicked');
                    eval(code);
                });
            }

        }
    }

    SetWhenClickedAttributeForElement(id) {
        var fatherElement = document.getElementById(id);
        var elements = fatherElement.childNodes
        for (var i = 0; i < elements.length; i++) {
            var element = elements[i];
            var hasAtt = element.hasAttribute("whenClicked");

            if (hasAtt) {
                element.addEventListener("click", function () {
                    var code = this.getAttribute('whenClicked');
                    eval(code);
                });
            }

        }
    }

}

window.temp = {
    Common: new Object(),
    Correios: new Object()
}
window.application = new App();
window.application.Initialize();