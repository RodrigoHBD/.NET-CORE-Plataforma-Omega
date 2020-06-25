
export default class CommonController {
    AskFormConfirmation(message, callback, params){
        try {
            application.Session.Common.ConfirmationWarning.Message = message;
            application.Session.Common.ConfirmationWarning.Params = params;
            application.Session.Common.ConfirmationWarning.Callback = callback;
            application.Controllers.Animations.PromptWarning();
        }
        catch(erro){
            throw erro;
        }
    }

    async ExecuteWarningCallback(){
        try {
            await application.Session.Common.ConfirmationWarning.Callback();
        }
        catch(erro){
            throw erro;
        }
    }
}