import { Pagination } from "/js/main-app/models/common.js";

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