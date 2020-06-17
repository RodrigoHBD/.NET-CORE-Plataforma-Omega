class VueController {
    isInitialized = false;
    VueInstance;

    Initialize(){
        try {
            this.VueInstance = new Vue({
                el: "#app",
                data: app.Session
            })
        } 
        catch (error) {
            throw error;    
        }
    }
}