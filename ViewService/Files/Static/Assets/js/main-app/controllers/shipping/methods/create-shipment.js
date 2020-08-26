import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";

export default class CreateShipment extends ShippingMethod {

    async Run() {

    }

    constructor(form_data) {
        this._FormData = form_data;
    }

    _FormData;

}
