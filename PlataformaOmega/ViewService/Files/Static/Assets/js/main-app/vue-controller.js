class VueController {
    isInitialized = false;
    VueInstance;

    Initialize(){
        try {
            this.VueInstance = new Vue({
                el: "#app",
                data: app.Session,
                computed: app.Computed
            })
        } 
        catch (error) {
            throw error;    
        }
    }
}