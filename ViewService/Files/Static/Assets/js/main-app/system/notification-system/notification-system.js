import { Notify } from "/js/main-app/system/notification-system/methods.js";

export default class NotificationSystem {
    Notify(notification) {
        var method = new Notify(notification);
        await method.Run();
    }

}