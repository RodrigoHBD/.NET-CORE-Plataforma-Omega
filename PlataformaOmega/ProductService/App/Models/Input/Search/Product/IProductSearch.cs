using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Models.Input
{
    public interface IProductSearch
    {
        ISearchStringDataField Owner { get; }
        ISearchStringDataField Id { get; }
        ISearchStringDataField Name { get; }
        ISearchStringDataField Category { get; }
        ISearchStringDataField Brand { get; }
        ISearchStringDataField Condition { get; }
        List<ISearchIntDataField> WarrantyTimeInDays { get; }
        IPaginationIn Pagination { get; }
    }
}
