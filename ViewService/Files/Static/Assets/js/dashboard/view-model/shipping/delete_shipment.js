import DeleteShipmentMethod from "/js/main-app/controllers/shipping/methods/delete_shipment.js";

export default class DeleteShipment {
    async Run(id){
        var method = new DeleteShipmentMethod();
        await method.Run(id);
    }
}