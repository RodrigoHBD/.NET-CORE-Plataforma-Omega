import UpdateShipmentTable from "/js/dashboard/view-model/shipping/update_shipment_table.js";
import CacheShipment from "/js/dashboard/view-model/shipping/cache_shipment.js";
import CacheShipmentEvents from "/js/dashboard/view-model/shipping/cache_shipment_events.js";

export default class ShippingMethods {
    async CreateShipment() {

    }

    async UpdateShipmentTable() {
        var method = new UpdateShipmentTable();
        await method.Run();
    }

    async ShowShipmentDetail(id) {
        var cache_shipment = new CacheShipment(id);
        var cache_events = new CacheShipmentEvents(id);
        await cache_shipment.Run();
        await cache_events.Run();
        toolbox.Events.Click("CorreiosTab-InnerTabs-DetailsTab");
    }

    async DeleteShipment(id) {

    }

}