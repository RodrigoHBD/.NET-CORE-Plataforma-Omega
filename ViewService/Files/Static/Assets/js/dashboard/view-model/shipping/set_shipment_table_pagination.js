import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";

export default class SetShipmentTablePagination extends BaseMethod {
    static GetForwardOffset() {
        return this._GetReactive().ShipmentTable.Pagination.Offset +
            this._GetReactive().ShipmentTable.Pagination.Limit;
    }

    static GetForwardLimit() {
        return this._GetReactive().ShipmentTable.Pagination.Limit;
    }

    static GetBackwardsOffset() {
        return this._GetReactive().ShipmentTable.Pagination.Offset -
            this._GetReactive().ShipmentTable.Pagination.Limit;
    }

    static GetBackwardsLimit() {
        return this._GetReactive().ShipmentTable.Pagination.Limit;
    }

    static _GetReactive() {
        return vue_app.ReactiveData.Shipping;
    }

    Run() {
        this.GetReactive().ShipmentTable.Pagination.Offset = this._Offset;
        this.GetReactive().ShipmentTable.Pagination.Limit = this._Limit;
        console.log("")
    }

    constructor({ offset, limit }) {
        super();
        this._Offset = offset;
        this._Limit = limit;
        console.log(offset, limit)
    }

    _Offset;

    _Limit;
}