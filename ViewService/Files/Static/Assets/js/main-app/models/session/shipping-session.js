import { Shipment } from "/js/main-app/models/shipping/shipping-models.js";

export default class ShippingSession {
    ShipmentTable = new ShipmentTable();
    CachedShipment = new Shipment();
}

class ShipmentTable {
    TotalPages = 0;
    CurrentPage = 0;
    Body = [];
}