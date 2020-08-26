import { Notification } from "/js/main-app/models/common.js";

export default class Notify {
    Run() {
        var notification = this._Notification;
        this._SetNotificationSpan();
        this._ShowNotificationSpan();
        this._SetHideNotificationSpanTimeout(notification.Lifetime);
    }

    constructor(notification = new Notification()) {
        this._Notification = notification;
    }

    _SetNotificationSpan() {
        try {
            var notification = this._Notification;
            application.Session.Common.NotificationSpan.Title = notification.Title;
            application.Session.Common.NotificationSpan.Text = notification.Text;
            application.Session.Common.NotificationSpan.Type = notification.Type;
        }
        catch (erro) {
            throw erro;
        }
    }

    _ShowNotificationSpan() {
        try {
            var isShowingNotificationSpan = application.Session.Common.NotificationSpan.IsVisible == true;
            if (!isShowingNotificationSpan) {
                document.getElementById("show-notification-span-btn").click();
                application.Session.Common.NotificationSpan.IsVisible = true;
            }
        }
        catch (error) {
            error;
        }
    }

    _HideNotificationSpan() {
        try {
            var isShowingNotificationSpan = application.Session.Common.NotificationSpan.IsVisible == true;
            if (isShowingNotificationSpan) {
                document.getElementById("show-notification-span-btn").click();
                application.Session.Common.NotificationSpan.IsVisible = false;
            }
        }
        catch (error) {
            error;
        }
    }

    _SetDeletionTimeout() {
        var notification = this._Notification;
        setTimeout(() => { this.DeleteNotification(notification.Id); }, notification.Lifetime);
    }

    _SetHideNotificationSpanTimeout(time) {
        var callback = () => { this.HideNotificationSpan(); }
        setTimeout(callback, time);
    }

    _Notification;
}