import { Notification } from "/js/main-app/models/models.js";

export default class ExceptionHandler {

    HandleApiCallException(e){
        try {
            var notification = new Notification();
            notification.Title = `Erro de chamada API`;
            notification.Text = e.message;
            notification.Type = "error";
            application.Controllers.Notification.Notify(notification);
        } 
        catch (error) {
            throw error;
        }
    }

}