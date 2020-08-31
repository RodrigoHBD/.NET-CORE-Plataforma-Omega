import ReactiveData from "/js/dashboard/reactive_data.js";
import Methods from "/js/dashboard/methods.js";

export default class VueApp {
    ReactiveData = new ReactiveData();
    Instance;

    Initialize() {
        this.BuildInstance();
    }

    BuildInstance() {
        try {
            this.Instance = new Vue({
                el: this._ElementId,
                data: this._GetData(),
                // WebFlow Animations FIX 
                mounted: this._WebfloxAnimationsFix
            })
        }
        catch (error) {
            throw error;
        }
    }

    _ElementId = "#app";

    _GetData() {
        this.ReactiveData.methods = new Methods();
        return this.ReactiveData;
    }

    _WebfloxAnimationsFix() {
        this.$nextTick(function () {
            //RE-INIT WF as Vue.js init breaks WF interactions
            Webflow.destroy();
            Webflow.ready();
            Webflow.require('ix2').init();
        });
    }
}