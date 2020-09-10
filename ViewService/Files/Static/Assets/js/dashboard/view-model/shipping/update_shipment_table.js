import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import SearchShipmentsMethod from "/js/main-app/controllers/shipping/methods/search-shipments.js";
import GetShipmentStatusColor from "/js/dashboard/view-model/shipping/get_shipment_status_color.js";
import { ShipmentSearch } from "/js/main-app/models/shipping/shipping-models.js";
import { SearchFilters } from "/js/main-app/models/common.js";
import SetBoundryAccountNames from "/js/dashboard/view-model/shipping/set_boundry_account_names.js";

export default class UpdateShipmentTable extends BaseMethod {

    async Run() {
        try {
            var req = this._GetRequest();
            var method = new SearchShipmentsMethod(req);
            var resp = await method.Run();
            return this._HandleResponse(resp);
        }
        catch (erro) {
            throw erro;
        }
    }

    constructor() {
        super();
    }

    _FormData;

    _GetFormData() {
        return toolbox.Form.GetFormData("shipment-filters-form");
    }

    _GetRequest() {
        this._FormData = this._GetFormData();
        var req = new ShipmentSearch();
        req.DynamicString = this._GetDynamicString();
        req.Posted = this._GetPostedFilter();
        req.Pagination = this._GetPagination();
        req.AwaitingForPickUp = this._GetAwaitingForPickUpFilter();
        req.Rejected = this._GetRejectedFilter();
        req.Delivered = this._GetDeliveredFilter();
        return req;
    }

    _GetPagination() {
        return vue_app.ReactiveData.Shipping.ShipmentTable.Pagination;
    }

    _GetDynamicString() {
        var filter = new SearchFilters.Boolean();
        var value = this._FormData.DynamicString;
        if (value.length > 0) {
            filter.IsActive = true;
        }
        filter.Value = value;
        return filter;
    }
    _GetPostedFilter() {
        var filter = new SearchFilters.Boolean();
        var awaitingForPosted = this._FormData.AwaitingForPosting;

        if (awaitingForPosted) {
            filter.IsActive = true;
        }
        filter.Value = false;
        return filter;
    }

    _GetAwaitingForPickUpFilter() {
        var filter = new SearchFilters.Boolean();
        var value = this._FormData.AwaitingForPickUp;

        if (value) {
            filter.IsActive = true;
        }
        filter.Value = true;
        return filter;
    }

    _GetRejectedFilter() {
        var filter = new SearchFilters.Boolean();
        var value = this._FormData.RejectedComingBack;

        if (value) {
            filter.IsActive = true;
        }
        filter.Value = true;
        return filter;
    }

    _GetDeliveredFilter() {
        var filter = new SearchFilters.Boolean();
        var rejectedReturning = this._FormData.RejectedComingBack;
        var delivered = this._FormData.Delivered;

        if (rejectedReturning) {
            filter.IsActive = true;
            filter.Value = false;
        }
        else if (delivered) {
            filter.IsActive = true;
            filter.Value = true;
        }
        else {
            filter.IsActive = false;
        }

        return filter;
    }

    _HandleResponse(resp) {
        this._SetShipmentProperties(resp);
        this._SetTableBody(resp);
        this._SetTablePagination(resp);
        new SetBoundryAccountNames().Run();
    }

    _SetTableBody(resp) {
        vue_app.ReactiveData.Shipping.ShipmentTable.Body = resp.Data;
    }

    _SetTablePagination(resp) {
        vue_app.ReactiveData.Shipping.ShipmentTable.Pagination = resp.Pagination;
        this._SetTotalPages();
        this._SetCurrentPage();
    }

    _SetTotalPages() {
        var number = 0;
        var total = vue_app.ReactiveData.Shipping.ShipmentTable.Pagination.Total;
        var limit = vue_app.ReactiveData.Shipping.ShipmentTable.Pagination.Limit;
        if (total > 0) {
            number = total / limit;
            if (number > 0) {
                var parsed = parseInt(number);
                if (number > parsed) {
                    number++;
                }
            }
        }
        vue_app.ReactiveData.Shipping.ShipmentTable.TotalPages = number;
    }

    _SetCurrentPage() {
        var number = 0;
        var total = vue_app.ReactiveData.Shipping.ShipmentTable.Pagination.Total;
        var limit = vue_app.ReactiveData.Shipping.ShipmentTable.Pagination.Limit;
        var offset = vue_app.ReactiveData.Shipping.ShipmentTable.Pagination.Offset;
        if (total > 0) {
            number = offset / limit;
        }
        vue_app.ReactiveData.Shipping.ShipmentTable.CurrentPage = number;
    }

    _SetShipmentProperties(resp) {
        var shipments = resp.Data;
        for (var shipment of shipments) {
            this._SetStatusStyleProps(shipment);
        };
    }

    _SetStatusStyleProps(shipment) {
        var get_color = new GetShipmentStatusColor(shipment);
        shipment.StatusInnerColor = get_color.GetInnerColor();
        shipment.StatusOuterColor = get_color.GetOuterColor();
    }

}