import ShippingReactive from "/js/dashboard/reactive-data/shipping_reactive.js";
import CommonReactive from "/js/dashboard/reactive-data/common_reactive.js";
import MercadoLivreReactive from "/js/dashboard/reactive-data/mercado_livre_reactive.js";
import WarningReactive from "/js/dashboard/reactive-data/warning_reactive.js";
import NotificationSpanReactive from "/js/dashboard/reactive-data/notification_span_reactive.js";

export default class ReactiveData {
    NotificationSpan = new NotificationSpanReactive();
    Common = new CommonReactive();
    Warning = new WarningReactive();
    Shipping = new ShippingReactive();
    MercadoLivre = new MercadoLivreReactive();
}