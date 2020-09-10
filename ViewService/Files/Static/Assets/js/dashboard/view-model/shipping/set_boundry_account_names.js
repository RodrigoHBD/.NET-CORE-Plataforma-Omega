import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import MLGetAccountData from "/js/dashboard/view-model/mercado-livre/get_account_data.js";

export default class SetBoundryAccountNames extends BaseMethod {
    async Run() {
        this._SetProperties();
        for (var shipment of this._Table) {
            var bound_marketplace = shipment.BoundMarketplace;

            if (bound_marketplace == "mercado livre") {
                var method = new MLGetAccountData();
                var data = await method.Run(shipment.MarketplaceAccountId);
                shipment.MarketplaceAccountId = data.Nickname;
            }

        }
    }

    _Table;

    _SetProperties() {
        this._Table = this.GetReactive().ShipmentTable.Body;
    }

}