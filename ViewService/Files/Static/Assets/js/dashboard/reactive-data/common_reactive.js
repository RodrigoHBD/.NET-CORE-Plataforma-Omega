import { Notification } from "/js/main-app/models/common.js";

export default class CommonReactive {
    ConfirmationWarning = new ConfirmationWarning();
    NotificationBox = new NotificationBox();
    NotificationSpan = new Notification();
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
