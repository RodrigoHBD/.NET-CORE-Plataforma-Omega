import { Pagination } from "/js/main-app/models/models.js";

export default class MercadoLivreSession {
    AccountsTable = new AccountsTable();
}

class AccountsTable {
    Filters = new AccountsTableFilters();
    Pagination = new Pagination();
    Body = new Array();
}

class AccountsTableFilters {
    DynamicString = "";
}