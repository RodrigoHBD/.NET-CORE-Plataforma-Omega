﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class PackageUseCases
    {
        public static RegisterPackage RegisterPackage { get; } = new RegisterPackage();
    }
}
