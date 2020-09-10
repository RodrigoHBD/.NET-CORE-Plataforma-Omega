import { Shipment, ShipmentEvents } from "/js/main-app/models/shipping/shipping-models.js";
import { Pagination } from "/js/main-app/models/common.js";

export default class ShippingReactive {
    ShipmentTable = new ShipmentTable();
    CachedShipment = new Shipment();
    CachedEvents = new ShipmentEvents();
    NewShipmentForm = new NewShipmentForm();
}

class ShipmentTable {
    TotalPages = 0;
    CurrentPage = 0;
    Body = [];
    Pagination = new Pagination();
}

class NewShipmentForm {
    IsLoading = false;
}