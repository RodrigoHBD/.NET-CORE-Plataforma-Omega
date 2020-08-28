class Package {
    Name = "#";
    TrackingCode = "#";
    SaleId = "#";
    BoundPlatform = "#";
    Weight = 0.00;
    IsBeingWatched = false;
    IsManuallyCreated = false;
    Messages = {
        StatusDescription: ""
    }
    Locations = {
        CurrentLocation: new Location(),
        HeadedToLocation: new Location()
    }
}

class Pagination {
    Offset = 0;
    Limit = 25;
    Total = 0;
}


class Location {
    City = "";
    State = "";
    StreetName = "";
    StreetNumber = 0;
    Cep = "";
}

// filters
class SearchFilter {
    IsActive = false;
}

class StringFilter extends SearchFilter {
    Value = "";
}

class BooleanFilter extends SearchFilter {
    Value = false;
}

var SearchFilters = {
    Boolean: BooleanFilter,
    String: StringFilter
}

class Notification {
    Id = 0;
    Title = "";
    Text = "";
    IsVisible = false;
    Type = "";
    Lifetime = 5000;
}

export { Package, Pagination, Location, SearchFilters, Notification };