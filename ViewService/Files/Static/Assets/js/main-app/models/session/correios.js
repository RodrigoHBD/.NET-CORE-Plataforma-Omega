import { Package, Pagination } from "/js/main-app/models/common.js";

export default class CorreiosSession {
    CachedPackage = new Package();
    ObjectsTable = new CorreiosObjectsTable();
    Initialize() {

    }
}

class CorreiosObjectsTable {
    Pagination;
    CurrentPage = () => { return parseInt(this.Pagination.Offset / this.Pagination.Limit) + 1 }
    TotalPages = () => {
        var num = this.Pagination.Total / this.Pagination.Limit;
        if (num > parseInt(num)) {
            num++
            num = parseInt(num)
        }
        else if (num > 0) {
            num = 1
        }
        else {
            num = 0
        }
        return num;
    }
    Body = new Array();

    constructor() {
        this.Pagination = new Pagination();
        this.Pagination.Limit = 25;
    }
}

class CorreiosObjectsTableFilters {
    Pagination = new Pagination();
}