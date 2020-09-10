import { Location, Pagination, SearchFilters } from "/js/main-app/models/common.js";

class Shipment {
    Id = "";
    TrackingCode = "";
    PackageId = "";
    BoundMarketplace = "";
    MarketplaceSaleId = "";
    MarketplaceAccountId = "";
    ShippingService = "";
    BoundryMessage = "";
    CreatedAt = "";
    States = new ShipmentStates();
}

class ShipmentStates {
    IsPosted = false;
    IsBeingTransported = false;
    IsAwaitingForPickUp = false;
    IsDelivered = false;
    IsDeliveredToDestination = false;
}

class ShipmentEvent {
    Title = "";
    Description = "";
    OccuredAt = "";
}

class CreatedEvent extends ShipmentEvent { }

class PostedEvent extends ShipmentEvent {
    IsPosted = false;
}

class ForwardingEvent extends ShipmentEvent {
    PackageHasArrived = false;
    BoundryMessage = "";
    ArrivedAt = "";
    ForwardedFrom = new Location();
    ForwardedTo = new Location();
}

class AwaitingForPickUpEvent extends ShipmentEvent {
    IsSet = false;
    Location = new Location();
}

class RejectedEvent extends ShipmentEvent {
    IsRejected = false;
}

class DeliveredEvent extends ShipmentEvent {
    IsDelivered = false;
    IsDeliveredToDestination = false;
}

class ShipmentEvents {
    CreatedEvent = new CreatedEvent();
    PostedEvent = new PostedEvent();
    AwaitingForPickUpEvent = new AwaitingForPickUpEvent();
    RejectedEvent = new RejectedEvent();
    DeliveredEvent = new DeliveredEvent();
    ForwardingEvents = [new ForwardingEvent()];
}

class ShipmentSearch {
    Pagination = new Pagination();
    DynamicString = new SearchFilters.String();
    IsPosted = new SearchFilters.Boolean();
}

class NewShipmentRequest {
    TrackingCode = "";
    BoundMarketplace = "";
    MarketplaceAccountId = "";
    MarketplaceSaleId = "";
    ShippingService = "";
    SetAutoUpdate = true;
    Package = new NewShipmentPackageData();
}

class NewShipmentPackageData {
    Name = "";
    WeightInGrams;
    WidthInMm;
    LengthInMm;
    HeightInMm;
    Content = new Array();
}

export {
    Shipment, ShipmentEvents, ShipmentSearch, NewShipmentRequest,
    NewShipmentPackageData
};