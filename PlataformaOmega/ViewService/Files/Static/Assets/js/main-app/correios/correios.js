import { Package, Pagination } from "/js/main-app/models.js";

export default class CorreiosSession {
    CachedPackage = new Package();
    ObjectsTable = new CorreiosObjectsTable();
    Initialize() {

    }
}

class CorreiosObjectsTable {
    Pagination = new Pagination();
    CurrentPage = () => { return parseInt(this.Pagination.Offset/this.Pagination.Limit) +1 }
    TotalPages = () =>{
        var num = this.Pagination.Total/this.Pagination.Limit;
        if(num > parseInt(num)){
            num++
            num = parseInt(num)
        }
        else if (num > 0){
            num = 1
        }
        else {
            num = 0
        }
        return num;
    }
    Body = new Array();
}

class CorreiosObjectsTableFilters {
    Pagination = new Pagination();
}