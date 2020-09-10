import WarningMethods from "/js/dashboard/view-model/warning_methods.js";
import ShippingMethods from "/js/dashboard/view-model/shipping_methods.js";
import NotificationSpanMethods from "/js/dashboard/view-model/notification_span_methods.js";
import MercadoLivreMethods from "/js/dashboard/view-model/mercado_livre_methods.js";

export default class Methods {
    Warning = new WarningMethods();
    NotificationSpan = new NotificationSpanMethods();
    Shipping = new ShippingMethods();
    MercadoLivre = new MercadoLivreMethods();
}