using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Entities.PackageStatusInterpreter
{
    public interface IPackageStateMatcher
    {
        string StateLabel { get; }
        bool Match(PackageStatus status);
        PackageActionHandler ActionHandler { get; }
    }
}
