import BaseMethod from "/js/dashboard/view-model/shipping/base_method.js";
import GetShipmentEvents from "/js/main-app/controllers/shipping/methods/get_shipment_events.js";

export default class CacheShipmentEvents extends BaseMethod {
    async Run() {
        try {
            var method = new GetShipmentEvents(this._Id);
            var events = await method.Run();
            this._SetEvents(events);
        } catch (error) {
            throw error;
        }
    }

    constructor(id) {
        super();
        this._Id = id;
    }

    _Id;

    _SetEvents(events) {
        events.ForwardingEvents.reverse();
        this.GetReactive().CachedEvents = events;
    }
}