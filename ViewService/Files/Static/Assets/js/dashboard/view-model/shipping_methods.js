export default class ShippingMethods {
    async UpdateShipmentsTable() {
        try {
            var foo = [{ TrackingCode: "Codigo rastre" }];
            vue_app.ReactiveData.Shipping.ShipmentTable.Body = foo;
        }
        catch (erro) {
            throw erro;
        }
    }
}