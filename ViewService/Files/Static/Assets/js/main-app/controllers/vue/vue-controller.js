export default class VueController {
    Initialize() {
        try {
            application.VueInstance = new Vue({
                el: "#app",
                data: application.Session,
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