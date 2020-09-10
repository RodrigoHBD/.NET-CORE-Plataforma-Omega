import UpdateShipmentTable from "/js/dashboard/view-model/shipping/update_shipment_table.js";
import CacheShipment from "/js/dashboard/view-model/shipping/cache_shipment.js";
import CacheShipmentEvents from "/js/dashboard/view-model/shipping/cache_shipment_events.js";
import CreateShipment from "/js/dashboard/view-model/shipping/create_shipment.js";
import RunAutoUpdate from "/js/dashboard/view-model/shipping/run_auto_update.js";
import SetShipmentTablePagination from "/js/dashboard/view-model/shipping/set_shipment_table_pagination.js";
import DeleteShipment from "/js/dashboard/view-model/shipping/delete_shipment.js";

export default class ShippingMethods {
    async CreateShipment() {
        var method = new CreateShipment();
        await method.Run();
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

    async RunAutoUpdate() {
        var method = new RunAutoUpdate();
        await method.Run();
    }

    async RunAutoUpdateById(id) {
        var method = new RunAutoUpdate();
        await method.RunById(id);
    }

    async DeleteShipment(id) {
        var method = new DeleteShipment();
        await method.Run(id);
        await vue_app.Methods.Shipping.UpdateShipmentTable();
    }

    async DeleteShipmentWithWarning(id) {
        var message = "Você está prestes a deletar um envio.";
        var callback = this.DeleteShipment;
        var callback_param = id;
        vue_app.Methods.Warning.AskForConfirmation({ message, callback, callback_param });
    }

    async PaginateShipmentTableForward() {
        var offset = SetShipmentTablePagination.GetForwardOffset();
        var limit = SetShipmentTablePagination.GetForwardLimit();
        var setPagination = new SetShipmentTablePagination({ offset, limit });
        setPagination.Run();
        await this.UpdateShipmentTable();
    }

    async PaginateShipmentTableBackwards() {
        var offset = SetShipmentTablePagination.GetBackwardsOffset();
        var limit = SetShipmentTablePagination.GetBackwardsLimit();
        var setPagination = new SetShipmentTablePagination({ offset, limit });
        setPagination.Run();
        await this.UpdateShipmentTable();
    }

    OpenTrackingWebsite(code){
        window.open(`https://linkcorreios.com.br/${code}`);
    }

}