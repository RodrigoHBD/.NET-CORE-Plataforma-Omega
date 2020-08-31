import App from "/js/main-app/app.js";
import VueApp from "/js/dashboard/vue_app.js";

window.application = new App();
window.application.Initialize();

window.vue_app = new VueApp();
window.vue_app.Initialize();