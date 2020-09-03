import { NotificationSpan } from "/js/dashboard/models/notification_span.js";

export default class CommonReactive {
    ConfirmationWarning = new ConfirmationWarning();
    NotificationBox = new NotificationBox();
    NotificationSpan = new NotificationSpan();
}

class NotificationBox {
    Body = new Array();
}

class ConfirmationWarning {
    Message = "";
    Toggler = false;
    Params = {};
    Callback = function () { };
}
