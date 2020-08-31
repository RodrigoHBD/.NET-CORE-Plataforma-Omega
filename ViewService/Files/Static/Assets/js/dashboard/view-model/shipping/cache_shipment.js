import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import GetShipment from "/js/main-app/controllers/shipping/methods/get_shipment.js";

export default class CacheShipment extends BaseMethod {
    async Run() {
        try {
            var shipment = await this._GetShipment();
            this.GetReactive().CachedShipment = shipment;
        }
        catch (erro) {
            throw erro;
        }
    }

    constructor(id) {
        super();
        this._Id = id;
    }

    _Id;

    _GetFromMemory() {
        var shipment = this.GetReactive().ShipmentTable.Body.find(ship => ship.Id == this._Id);
        return shipment;
    }

    async _GetFromServer() {
        var method = new GetShipment(this._Id);
        return await method.Run();
    }

    async _GetShipment() {
        var shipment = this._GetFromMemory();
        var IsCached = typeof shipment == "object";

        if (!IsCached) {
            shipment = await this._GetFromServer();
        }
        return shipment;
    }

}