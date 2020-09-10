import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";

export default class SetNewShipmentForm extends BaseMethod {
    SetLoadingOn() {
        this.GetReactive().NewShipmentForm.IsLoading = true;
    }

    SetLoadingOff() {
        this.GetReactive().NewShipmentForm.IsLoading = false;
    }

    constructor() {
        super();
    }
}