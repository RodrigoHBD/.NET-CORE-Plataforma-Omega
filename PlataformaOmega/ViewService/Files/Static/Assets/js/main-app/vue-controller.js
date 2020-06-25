export default class VueController {
    isInitialized = false;
    VueInstance;

    Initialize(){
        try {
            this.VueInstance = new Vue({
                el: "#app",
                data: application.Session,
                //computed: app.Computed,
                // WebFlow Animations FIX 
                mounted: function () {
                    this.$nextTick(function () {
                        //RE-INIT WF as Vue.js init breaks WF interactions
                        Webflow.destroy();
                        Webflow.ready();
                        Webflow.require('ix2').init();
                    });
                }
            })
        } 
        catch (error) {
            throw error;    
        }
    }
}