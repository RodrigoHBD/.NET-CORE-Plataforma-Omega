import VueController from "/js/main-app/controllers/vue/vue-controller.js";
import CommonController from "/js/main-app/controllers/common/common-controller.js";
import AnimationsController from '/js/main-app/controllers/animations/animations-controller.js';
import MercadoLivreController from '/js/main-app/controllers/mercado-livre/mercado-livre-controller.js';
import ShippingController from '/js/main-app/controllers/shipping/shipping-controller.js';

export default class Controllers {
    Common = new CommonController();
    Animations = new AnimationsController();
    Vue = new VueController();
    MercadoLivre = new MercadoLivreController();
    Shipping = new ShippingController();
}