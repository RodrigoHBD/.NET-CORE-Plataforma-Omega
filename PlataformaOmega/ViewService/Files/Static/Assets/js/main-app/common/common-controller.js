
export default class CommonController {
    AskForConfirmation(message, callback, params){
        try {
            console.log("Ceeeee")
            application.Session.Common.ConfirmationWarning.Message = message;
            application.Session.Common.ConfirmationWarning.Params = params;
            window.Callback = callback;
            application.Controllers.Animations.PromptWarning();
        }
        catch(erro){
            throw erro;
        }
    }

    async ExecuteWarningCallback(){
        try {
            //await window.Callback();
            application.Controllers.Animations.HideWarning();
        }
        catch(erro){
            throw erro;
        }
    }
}