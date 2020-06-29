import { Pagination } from "/js/main-app/models.js";

export default class CorreiosController {
    BaseUri = "/api/shipping";

    async SearchPackages() {
        try {
            var pagination = this.GetCurrentPagination();
            var filters = this.GetFilters();
            var request = this.BuildSearchPackagesRequest(pagination, filters);
            var response = await application.HttpClient.Post(`${this.BaseUri}/search-package`, request);
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
            var response = await application.HttpClient.Get(`${this.BaseUri}/get-package`, params);
            return response.body;
        }
        catch (error) {
            throw error;
        }
    }

    GetPackageDetailFromMemory(id) {
        try {
            var pack = application.Session.Correios.ObjectsTable.Body.find(_package => _package.Id === id);
            return pack;
        }
        catch (error) {
            throw error;
        }
    }

    async ShowPackageDetail(id) {
        try {
            //var id = element.getAttribute("package_id")
            var data = this.GetPackageDetailFromMemory(id);
            this.UpdatePackageDetail(data);
            document.getElementById("CorreiosTab-InnerTabs-DetailsTab").click();
        }
        catch (erro) {
            throw erro;
        }
    }

    async DeletePackage() {
        try {
            console.log("taaaa")
            var id = application.Session.Common.ConfirmationWarning.Params.id;
            var uri = `${application.Controllers.Correios.BaseUri}/delete-package`;
            var param = new QueryStringParamModel();
            param.name = "id";
            param.value = id;
            await application.HttpClient.Delete(uri, [param])
            //await application.Controllers.Correios.SearchPackages();
        }
        catch (error) {
            throw error;
        }
    }

    DeletePackageWithPrompt(id) {
        try {
            console.log("BOOOO")
            var callback = this.DeletePackage;
            application.Controllers.Common.AskForConfirmation("Tem certeza que deseja deletar?", callback, { id });
        }
        catch (error) {
            throw error;
        }
    }

    UpdatePackageDetail(data) {
        try {
            application.Session.Correios.CachedPackage = data;
        }
        catch (erro) {
            throw erro;
        }
    }

    UpdateObjectsTable(response) {
        try {
            application.Session.Correios.ObjectsTable.Body = response.Data;
            application.Session.Correios.ObjectsTable.Pagination.Limit = response.Pagination.Limit;
            application.Session.Correios.ObjectsTable.Pagination.Offset = response.Pagination.Offset;
            application.Session.Correios.ObjectsTable.Pagination.Total = response.Pagination.Total;
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

            await application.HttpClient.Post(`${this.BaseUri}/new-package`, request);
        }
        catch (error) {
            throw error;
        }
    }

    BuildNewPackageRequest(data) {
        try {
            data.IsManuallyCreated = true;
            data.Platform = -1;
            if (isNaN(parseFloat(data.Weight))) {
                data.Weight = 0;
            }
            else {
                data.Weight = parseFloat(data.Weight);
            }
            //////////////////////
            if (isNaN(parseInt(data.StreetNumber))) {
                data.StreetNumber = 0;
            }
            else {
                data.StreetNumber = parseInt(data.StreetNumber);
            }
            ////////
            data.SetWatcher = true;

            return data;
        }
        catch (error) {
            throw error;
        }
    }

    GetPackageStatusCssClass(id) {
        try {
            var _package = this.GetPackageDetailFromMemory(id);
            var isPosted = _package.Status.IsPosted;
            var isDelivered = _package.Status.IsDelivered;
            var isAwaitingForPickUp = _package.Status.IsAwaitingForPickUp;
            var isBeingTransported = _package.Status.IsBeingTransported;
            var isRejected = _package.Status.IsRejected;

            if (isDelivered && isRejected) {
                return "statusball-red";
            }
            else if (isDelivered && !isRejected) {
                return "statusball-green";
            }
            else if (isAwaitingForPickUp) {
                return "statusball-orange";
            }
            else if (isBeingTransported) {
                return "statusball-yellow";
            }
            else if (isPosted) {
                return "statusball-gray";
            }
            else {
                return "statusball-white-blackborder";
            }
        }
        catch (erro) {
            throw erro;
        }
    }

}

class SearchPackagesRequestModel {
    Name = "";
    Pagination = new Pagination();
}