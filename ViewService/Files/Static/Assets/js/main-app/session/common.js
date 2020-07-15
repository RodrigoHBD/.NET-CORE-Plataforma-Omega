export default class CommonSession {
    UserData = new UserData();
    ConfirmationWarning = new ConfirmationWarning();
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