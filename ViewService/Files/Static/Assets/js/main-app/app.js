import System from "/js/main-app/system/system.js";
import Controllers from "/js/main-app/controllers/controllers.js";
import ExceptionHandler from "/js/main-app/system/exception-handler-system/exception-handler-system.js";
import HttpClient from "/js/http-client/http-client.js";
import Session from "/js/main-app/models/session/session.js";

export default class App {
    System = new System();
    IsInitialized = false;
    Controllers;
    Session;
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
            this.IsInitialized = true;
        }
        catch (erro) {
            throw erro;
        }
    }

    InitialzieControllers() {
        try {
            this.Controllers = new Controllers();
        }
        catch (error) {
            throw error;
        }
    }

    InitializeSession() {
        try {
            this.Session = new Session();
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
