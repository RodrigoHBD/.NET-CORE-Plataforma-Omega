class Shipment {
    Id = "";
    TrackingCode = "";
    PackageId = "";
    BoundMarketplace = "";
    MarketplaceSaleId = "";
    MarketplaceAccountId = "";
    ShippingService = "";
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
}

class ShipmentEvents {
    CreatedEvent = new CreatedEvent();
    PostedEvent = new PostedEvent();
    ForwardingEvents = [new ForwardingEvent()];
}

export { Shipment, ShipmentEvents };