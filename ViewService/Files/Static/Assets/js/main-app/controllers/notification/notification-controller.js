import { Notification } from "/js/main-app/models/common.js";

export default class NotificationController {

    IsShowingNotificationSpan = false;

    PushNotification(notification, lifetime = 6000) {
        try {
            notification.Id = application.Session.Common.NotificationBox.Body.length + 1;
            notification.Lifetime = 6000;
            this.ShowNotification(notification);
        } catch (error) {
            throw error;
        }
    }

    Notify(notification) {
        try {
            this.SetNotificationSpan(notification);
            this.ShowNotificationSpan();
            this.SetHideNotificationSpanTimeout(notification.Lifetime);
        }
        catch (error) {

        }
    }

    SetNotificationSpan(notification) {
        try {
            application.Session.Common.NotificationSpan.Title = notification.Title;
            application.Session.Common.NotificationSpan.Text = notification.Text;
            application.Session.Common.NotificationSpan.Type = notification.Type;
        }
        catch (erro) {
            throw erro;
        }
    }

    ShowNotificationSpan() {
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

    HideNotificationSpan() {
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

    SetDeletionTimeout(notification) {
        setTimeout(() => { this.DeleteNotification(notification.Id); }, notification.Lifetime);
    }

    SetHideNotificationSpanTimeout(time) {
        var callback = () => { this.HideNotificationSpan(); }
        setTimeout(callback, time);
    }

    DeleteFromNotificationBox(id) {

    }

}