class CorreiosController {
    BaseUri = "/api/shipping";

    async SearchPackages() {
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

    GetCurrentPagination() {
        return new Pagination();
    }

    GetFilters() {
        return { name: "" };
    }

    BuildSearchPackagesRequest(pagination, filters) {
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

    async GetPackageDetail(id) {
        try {
            var params = [];
            var idParam = new QueryStringParamModel();
            idParam.name = "id";
            idParam.value = id;
            params.push(idParam);
            var response = await app.HttpClient.Get(`${this.BaseUri}/get-package`, params);
            return response.body;
        }
        catch (error) {
            throw error;
        }
    }

    async GetPackageDetailFromMemory(id) {
        try {
            var pack = app.Session.Correios.ObjectsTable.Body.find(_package => _package.Id === id);
            return pack;
        }
        catch (error) {
            throw error;
        }
    }

    async ShowPackageDetail(element) {
        try {
            var id = element.getAttribute("package_id")
            var data = await this.GetPackageDetailFromMemory(id);
            this.UpdatePackageDetail(data);
            document.getElementById("correios-open-detailbtn").click();
        }
        catch (erro) {
            throw erro;
        }
    }

    async DeletePackage(element) {
        try {
            var id = element.getAttribute("package_id")
            var uri = `${this.BaseUri}/delete-package`;
            var param = new QueryStringParamModel();
            param.name = "id";
            param.value = id;
            await app.HttpClient.Delete(uri, [param])
            await this.SearchPackages();
        }
        catch (error) {
            throw error;
        }
    }

    UpdatePackageDetail(data) {
        try {
            app.Session.Correios.CachedPackage = data;
        }
        catch (erro) {
            throw erro;
        }
    }

    UpdateObjectsTable(response) {
        try {
            app.Session.Correios.ObjectsTable.Body = response.Data;
            app.Session.Correios.ObjectsTable.Pagination.Limit = response.Pagination.Limit;
            app.Session.Correios.ObjectsTable.Pagination.Offset = response.Pagination.Offset;
            app.Session.Correios.ObjectsTable.Pagination.Total = response.Pagination.Total;
            app.SetWhenClickedAttribute();
        }
        catch (error) {
            throw error;
        }
    }

    async CreateNewPackage() {
        try {
            var data = toolbox.Form.GetFormData("correios-new-package-form");
            var request = this.BuildNewPackageRequest(data);
            console.log({ request });

            await app.HttpClient.Post(`${this.BaseUri}/new-package`, request);
        }
        catch (error) {
            throw error;
        }
    }

    BuildNewPackageRequest(data) {
        try {
            data.IsManuallyCreated = true;
            data.Platform = -1;
            if(isNaN(parseFloat(data.Weight))){
                data.Weight = 0;
            }
            else {
                data.Weight = parseFloat(data.Weight);
            }
            //////////////////////
            if(isNaN(parseInt(data.StreetNumber))){
                data.StreetNumber = 0;
            }
            else {
                data.StreetNumber = parseInt(data.StreetNumber);
            }
            ////////
            if(data.SetWatcher){
                data.SetWatcher = true;
            }
            else {
                data.SetWatcher = false;
            }
            
            return data;
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