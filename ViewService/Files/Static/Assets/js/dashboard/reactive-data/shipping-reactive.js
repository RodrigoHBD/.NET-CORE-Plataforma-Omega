import { Shipment, ShipmentEvents } from "/js/main-app/models/shipping/shipping-models.js";

export default class ShippingReactive {
    ShipmentTable = new ShipmentTable();
    CachedShipment = new Shipment();
    CachedEvents = new ShipmentEvents();
}

class ShipmentTable {
    TotalPages = 0;
    CurrentPage = 0;
    Body = [];
}