import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";
import { SearchFilters } from "/js/main-app/models/common.js";

export default class SearchShipments extends ShippingMethod {

    async Run() {
        var req = this._GetSearchRequest();
    }

    constructor(form_data) {
        this._FormData = form_data;
    }

    _FormData;

    _GetSearchRequest() {
        var req = new ShipmentSearch();
        req.DynamicString = this._GetDynamicString();
    }

    _GetDynamicString() {
        var filter = new SearchFilters.String();
        if (this._FormData.DynamicString.length > 0) {
            filter.IsActive = true;
            filter.Value = this._FormData.DynamicString;
        }
    }
}

class ShipmentSearch {
    DynamicString = new SearchFilters.String();
}