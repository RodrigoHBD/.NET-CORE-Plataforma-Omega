export default class CommonSession {
    ConfirmationWarning = new ConfirmationWarning();
}

class ConfirmationWarning {
    Message = "";
    Toggler = false;
    Params = {};
    Callback = function(){};
}