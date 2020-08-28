import App from "/js/main-app/app.js";
import VueApp from "/js/dashboard/vue_app.js";
import Methods from "/js/dashboard/methods.js";

window.application = new App();
window.application.Initialize();

window.methods = new Methods();

window.vue_app = new VueApp();
window.vue_app.Initialize();