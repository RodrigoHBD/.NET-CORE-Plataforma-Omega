import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";
import { SearchFilters } from "/js/main-app/models/common.js";

export default class SearchShipments extends ShippingMethod {

    async Run() {
        var uri = this._GetUri();
        var req = this._GetSearchRequest();
        var response = await application.HttpClient.Post(uri, request);
        await application.HttpClient.Helpers.ResponseHanlder.HandleResponse(response);
    }

    constructor(form_data) {
        this._FormData = form_data;
    }

    _FormData;

    _GetUri() {
        return "";
    }

    _GetSearchRequest() {
        var req = new ShipmentSearch();
        req.DynamicString = this._GetDynamicString();
        req.IsPosted = this._GetIsPosted();
    }

    _GetIsPosted() {
        var filter = new SearchFilters.Boolean();
        filter.IsActive = this._FormData.IsPosted;
        filter.Value = this._FormData.IsPosted;
    }

    _GetDynamicString() {
        var filter = new SearchFilters.String();

        if (this._FormData.DynamicString.length > 0) {
            filter.IsActive = true;
            filter.Value = this._FormData.DynamicString;
        }
        return filter;
    }
}

class ShipmentSearch {
    DynamicString = new SearchFilters.String();
    IsPosted = new SearchFilters.Boolean();
}