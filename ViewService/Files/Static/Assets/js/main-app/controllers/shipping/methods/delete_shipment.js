export default class DeleteShipmentMethod {
    async Run(id) {
        try {
            var uri = this._GetUri(id);
            var response = await application.HttpClient.Delete(uri);
            //return application.HttpClient.Helpers.ResponseHandler.HandleResponse(response);
        } 
        catch (error) {
            throw error;
        }
    }

    _GetUri(id){
        return `/api/shipping/shipment?id=${id}`;
    }
}