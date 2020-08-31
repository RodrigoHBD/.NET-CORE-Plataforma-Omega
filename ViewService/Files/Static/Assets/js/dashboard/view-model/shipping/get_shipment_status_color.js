import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";

export default class GetShipmentStatusColor extends BaseMethod {
    GetOuterColor() {
        var states = this._Shipment.States;

        if (states.IsBeingTransported) {
            return "rgba(223, 193, 0, 1.0)";
        }
        else if (states.IsAwaitingForPickUp) {
            return "rgba(255, 135, 15, 1.0)";
        }
        else {
            return "rgba(0, 0, 0, 0.23)";;
        }
    }

    GetInnerColor() {
        var states = this._Shipment.States;

        if (states.IsDelivered) {
            if (states.IsDeliveredToDestination) {
                return "rgba(56, 177, 0, 1.0)";
            }
            return "rgba(210, 0, 0, 1.0)";
        }
        return "rgba(255, 255, 255, 0.23)";
    }

    constructor(shipment) {
        super();
        this._Shipment = shipment;
    }

    _Shipment;

    _GetShipmentFromMemory(id) {
        var shipment = this.GetReactive().ShipmentTable.Body.find(ship => ship.Id == id);
        return shipment;
    }
}