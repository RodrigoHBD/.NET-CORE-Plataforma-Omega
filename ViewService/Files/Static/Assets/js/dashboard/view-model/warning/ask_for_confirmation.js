import BaseMethod from "/js/dashboard/view-model/warning/base_method.js";

export default class AskForConfirmation extends BaseMethod {
    Run({ message, callback, callback_param, update }) {
        if(!update){
            update = new Function();
        }
        this._SetMessage(message);
        this._SetAction(callback);
        this._SetParam(callback_param);
        this._SetUpdate(update);
        this.Show();
    }

    async RunAction() {
        var param = this.GetReactive().Param;
        await this.GetReactive().Action(param);
        this.Hide();
        await this.GetReactive().Update();
    }

    Show() {
        toolbox.Events.Click("show-warning-span");
    }

    Hide() {
        toolbox.Events.Click("hide-warning-span");
    }

    constructor() {
        super();
    }

    _SetMessage(message) {
        this.GetReactive().Text = message;
    }

    _SetAction(callback) {
        this.GetReactive().Action = callback;
    }

    _SetParam(param) {
        this.GetReactive().Param = param;
    }

    _SetUpdate(update){
        this.GetReactive().Update = update;
    }
}