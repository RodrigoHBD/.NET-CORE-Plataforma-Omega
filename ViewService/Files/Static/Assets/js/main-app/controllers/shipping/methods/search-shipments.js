import ShippingMethod from "/js/main-app/controllers/shipping/base-method.js";
import { SearchFilters } from "/js/main-app/models/common.js";

class SearchShipmentsMethod extends ShippingMethod {

    async Run() {
        var uri = this._GetUri();
        var req = this._Search;
        var response = await application.HttpClient.Post(uri, req);
        return await application.HttpClient.Helpers.ResponseHandler.HandleResponse(response);
    }

    constructor(search) {
        super();
        this._Search = search;
    }

    _Search;

    _GetUri() {
        return "/api/shipping/search-shipments";
    }

}

export default SearchShipmentsMethod;