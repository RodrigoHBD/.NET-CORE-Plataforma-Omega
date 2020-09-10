import BaseMethod from "/js/dashboard/view-model/notification-span/base_method.js";

//TODO encapsulate all methods
export default class ControllNotificationSpan extends BaseMethod {
    CssClass = "normal-notification";

    Notify(span) {
        this._SetSpanContent(span);
        this.Show();
        this._SetHideTimeout(span.Lifetime);
    }

    Show() {
        toolbox.Events.Click("show-notification-span");
    }

    Hide() {
        toolbox.Events.Click("hide-notification-span")
    }

    _SetSpanContent(span) {
        this.GetReactive().Title = span.Title;
        this.GetReactive().Text = span.Text;
    }

    _SetHideTimeout(time) {
        setTimeout(() => {
            this.Hide();
        }, time);
    }
}