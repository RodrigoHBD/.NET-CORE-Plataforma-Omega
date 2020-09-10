import AskForConfirmation from "/js/dashboard/view-model/warning/ask_for_confirmation.js";

export default class WarningMethods {
    AskForConfirmation(params) {
        var method = new AskForConfirmation();
        method.Run(params);
    }

    async RunAction(){
        var method = new AskForConfirmation();
        await method.RunAction();
    }

}