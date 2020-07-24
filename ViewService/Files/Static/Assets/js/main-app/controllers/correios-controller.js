import { Pagination, SearchFields } from "/js/main-app/models/models.js";

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
        try {
            var pagination = new Object();
            var data = toolbox.Form.GetFormData("correios-search-filters-form");
            var manualOffsetValid = !isNaN(parseInt(data.PageOffset)) && parseInt(data.PageOffset) !== 0;

            if (manualOffsetValid) {
                pagination.Offset = parseInt(data.PageOffset);
            }
            else {
                pagination.Offset = application.Session.Correios.ObjectsTable.Pagination.Offset
            }
            return pagination;
        }
        catch (error) {
            throw error;
        }
    }

    GetFilters() {
        try {
            var filters = new Object();
            var data = toolbox.Form.GetFormData("correios-search-filters-form");
            return data;
        }
        catch (error) {
            throw error;
        }
    }

    async PaginateForward() {
        try {
            application.Session.Correios.ObjectsTable.Pagination.Offset = application.Session.Correios.ObjectsTable.Pagination.Offset + 25;
            await this.SearchPackages();
        }
        catch (erro) {
            throw erro;
        }
    }

    async PaginateBackwards() {
        try {
            application.Session.Correios.ObjectsTable.Pagination.Offset = application.Session.Correios.ObjectsTable.Pagination.Offset - 25;
            await this.SearchPackages();
        }
        catch (erro) {
            throw erro;
        }
    }

    BuildSearchPackagesRequest(pagination, filters) {
        try {
            var request = new SearchPackagesRequestModel();
            request.DynamicString = filters.DynamicString;
            request.Pagination.Limit = pagination.Limit;
            request.Pagination.Offset = pagination.Offset;

            if(filters.BeingTransported){
                request.BeingTransported.IsActive = true;
                request.BeingTransported.Value = true
            }
            if(filters.AwaitingForPickUp){
                request.AwaitingForPickUp.IsActive = true;
                request.AwaitingForPickUp.Value = true
            }
            if(filters.Rejected){
                request.Rejected.IsActive = true;
                request.Rejected.Value = true
            }
            if(filters.Delivered){
                request.Delivered.IsActive = true;
                request.Delivered.Value = true
            }
            
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
            var id = application.Session.Common.ConfirmationWarning.Params.id;
            var uri = `${application.Controllers.Correios.BaseUri}/delete-package`;
            var param = new QueryStringParamModel();
            param.name = "id";
            param.value = id;
            await application.HttpClient.Delete(uri, [param])
            await application.Controllers.Correios.SearchPackages();
        }
        catch (error) {
            throw error;
        }
    }

    DeletePackageWithPrompt(id) {
        try {
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
            await application.HttpClient.Post(`${this.BaseUri}/new-package`, request);
            application.Controllers.Correios.FlushNewPackageForm();
            await application.Controllers.Correios.SearchPackages();
        }
        catch (error) {
            throw error;
        }
    }

    async CreateNewPackageOnEnterPressed(event) {
        try {
            if (event.keyCode == 13) {
                await application.Controllers.Correios.CreateNewPackage();
            }
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

    FlushNewPackageForm() {
        try {
            document.getElementById("correios-new-package-form").reset();
        }
        catch (erro) {
            throw erro;
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
            else if (isBeingTransported && isRejected) {
                return "statusball-yellow-redborder"
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

    OpenCorreiosLinksPage(trackingCode){
        window.open(`https://linkcorreios.com.br/${trackingCode}`);
    }

}

class SearchPackagesRequestModel {
    Name = "";
    DynamicString = "";
    BeingTransported = new SearchFields.Boolean();
    AwaitingForPickUp = new SearchFields.Boolean();
    Rejected = new SearchFields.Boolean();
    Delivered = new SearchFields.Boolean();
    Pagination = new Pagination();
}