import ControllNotificationSpan from "/js/dashboard/view-model/notification-span/controll_notification_span.js"

export default class NotificationSpanMethods {
    Notify(span){
        var span_controller = new ControllNotificationSpan();
        span_controller.Notify(span);
    }
}