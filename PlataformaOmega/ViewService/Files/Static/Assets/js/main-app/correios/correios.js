class CorreiosSession {
    CachedPackage = new Package();
    ObjectsTable = new CorreiosObjectsTable();
    Initialize() {

    }
}

class CorreiosComputed {
    CurrentPage = () => {
        return parseInt(Correios.ObjectsTable.Pagination.Offset / Correios.ObjectsTable.Pagination.Limit + 1);
    }
}

class CorreiosObjectsTable {
    Pagination = new Pagination();
    CurrentPage = () => { return parseInt(this.Pagination.Offset/this.Pagination.Limit) +1 }
    TotalPages = () =>{
        var num = this.Pagination.Total/this.Pagination.Limit;
        if(num > parseInt(num)){
            num++
        }
        return num;
    }
    Body = new Array();
}

class CorreiosObjectsTableFilters {
    Pagination = new Pagination();
}