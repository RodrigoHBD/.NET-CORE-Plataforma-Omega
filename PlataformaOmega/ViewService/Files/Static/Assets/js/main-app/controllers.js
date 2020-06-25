import CorreiosController from "/js/main-app/correios/correios-controller.js";
import VueController from "/js/main-app/vue-controller.js";
import SessionController from "/js/main-app/session-controller.js";
import ComputedController from "/js/main-app/computed-controller.js";
import CommonController from "/js/main-app/common/common-controller.js";
import AnimationsController from '/js/main-app/animations/animations-controller.js';

export default class Controllers {
    Common = new CommonController();
    Animations = new AnimationsController();
    Correios = new CorreiosController();
    Vue = new VueController();
    Session = new SessionController();
    Computed = new ComputedController();
}