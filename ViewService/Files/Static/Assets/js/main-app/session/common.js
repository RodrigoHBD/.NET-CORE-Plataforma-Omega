import { Notification } from "/js/main-app/models/models.js";

export default class CommonSession {
    UserData = new UserData();
    ConfirmationWarning = new ConfirmationWarning();
    NotificationBox = new NotificationBox();
    NotificationSpan = new Notification();
}

class ConfirmationWarning {
    Message = "";
    Toggler = false;
    Params = {};
    Callback = function(){};
}

class UserData {
    Username = "";
    Token = "";
}

class NotificationBox {
    Body = new Array();
}
