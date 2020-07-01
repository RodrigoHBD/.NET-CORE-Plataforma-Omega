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

export { Package, Pagination, Location };