import ReactiveData from "/js/dashboard/reactive_data.js";
import Methods from "/js/dashboard/methods.js";

export default class VueApp {
    Methods = new Methods();
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
                mounted: this._WebflowAnimationsFix
            })
        }
        catch (error) {
            throw error;
        }
    }

    RunWebflowFix() {
        Webflow.destroy();
        Webflow.ready();
        Webflow.require('ix2').init();
    }

    _ElementId = "#app";

    _GetData() {
        this.ReactiveData.methods = new Methods();
        return this.ReactiveData;
    }

    _WebflowAnimationsFix() {
        this.$nextTick(function () {
            //RE-INIT WF as Vue.js init breaks WF interactions
            Webflow.destroy();
            Webflow.ready();
            Webflow.require('ix2').init();
        });
    }


}