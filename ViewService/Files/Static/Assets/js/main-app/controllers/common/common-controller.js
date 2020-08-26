
export default class CommonController {
    AskForConfirmation(message, callback, params) {
        try {
            application.Session.Common.ConfirmationWarning.Message = message;
            application.Session.Common.ConfirmationWarning.Params = params;
            application.Session.Common.ConfirmationWarning.Callback = callback;
            application.Controllers.Animations.PromptWarning();
        }
        catch (erro) {
            throw erro;
        }
    }

    async ExecuteWarningCallback() {
        try {
            var callbackExists = application.Session.Common.ConfirmationWarning.Callback != null

            if (callbackExists) {
                await application.Session.Common.ConfirmationWarning.Callback();
            }

            this.FlushCallback();
            application.Controllers.Animations.HideWarning();
        }
        catch (erro) {
            throw erro;
        }
    }

    FlushCallback() {
        try {
            application.Session.Common.ConfirmationWarning.Callback = null;
        }
        catch (erro) {
            throw erro;
        }
    }
}