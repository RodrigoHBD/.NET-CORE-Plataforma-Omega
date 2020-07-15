import CorreiosController from "/js/main-app/controllers/correios-controller.js";
import VueController from "/js/main-app/controllers/vue-controller.js";
import SessionController from "/js/main-app/controllers/session-controller.js";
import ComputedController from "/js/main-app/controllers/computed-controller.js";
import CommonController from "/js/main-app/controllers/common-controller.js";
import AnimationsController from '/js/main-app/controllers/animations-controller.js';
import MercadoLivreController from '/js/main-app/controllers/mercado-livre-controller.js';

export default class Controllers {
    Common = new CommonController();
    Animations = new AnimationsController();
    Correios = new CorreiosController();
    Vue = new VueController();
    Session = new SessionController();
    Computed = new ComputedController();
    MercadoLivre = new MercadoLivreController();
}