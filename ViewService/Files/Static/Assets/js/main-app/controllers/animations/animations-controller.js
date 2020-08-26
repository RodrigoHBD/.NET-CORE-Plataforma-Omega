export default class AnimationsController {
    PromptWarning(){
        try {
            document.getElementById("app-actions-show-confirmation-warning").click();
        }
        catch(erro){
            throw erro;
        }
    }
    
    HideWarning(){
        try {
            document.getElementById("close-warning-box-btn").click();
        }
        catch(erro){
            throw erro;
        }
    }
}