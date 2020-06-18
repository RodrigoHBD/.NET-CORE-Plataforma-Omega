class CorreiosController {
    BaseUri = "/api/shipping";

    async SearchPackages(){
        try {
            var pagination = this.GetCurrentPagination();
            var filters = this.GetFilters();
            var request = this.BuildSearchPackagesRequest(pagination, filters);
            var response = await app.HttpClient.Post(`${this.BaseUri}/search-package`, request);
            this.UpdateObjectsTable(response.body);
        } 
        catch (error) {
            throw error;
        }
    }

    GetCurrentPagination(){
        return new Pagination();
    }

    GetFilters(){
        return { name: "" };
    }

    BuildSearchPackagesRequest(pagination, filters){
        try {
            var request = new SearchPackagesRequestModel();
            request.Name = filters.name;
            request.Pagination.Limit = pagination.Limit;
            request.Pagination.Offset = pagination.Offset;
            return request;
        } 
        catch (error) {
            throw error;
        }
    }

    async GetPackageDetail(id){

    }

    UpdateObjectsTable(response){
        try {
            app.Session.Correios.ObjectsTable.Body = response.Data;
            app.Session.Correios.ObjectsTable.Pagination.Limit = response.Pagination.Limit;
            app.Session.Correios.ObjectsTable.Pagination.Offset = response.Pagination.Offset;
            app.Session.Correios.ObjectsTable.Pagination.Total = response.Pagination.Total;
        } 
        catch (error) {
            throw error;
        }
    }
}

class SearchPackagesRequestModel {
    Name = "";
    Pagination = new Pagination();
}