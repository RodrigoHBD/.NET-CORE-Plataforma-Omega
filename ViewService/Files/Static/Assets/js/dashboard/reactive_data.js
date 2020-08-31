import ShippingReactive from "/js/dashboard/reactive-data/shipping_reactive.js";
import CommonReactive from "/js/dashboard/reactive-data/common_reactive.js";
import MercadoLivreReactive from "/js/dashboard/reactive-data/mercado_livre_reactive.js";

export default class ReactiveData {
    Common = new CommonReactive();
    Shipping = new ShippingReactive();
    MercadoLivre = new MercadoLivreReactive();
}