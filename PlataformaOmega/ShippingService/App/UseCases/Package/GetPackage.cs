﻿using ShippingService.App.Boundries;
using ShippingService.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class GetPackage
    {
        public static async Task<Package> Execute(string id)
        {
            try
            {
                return await PackageDAO.GetPackage(id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}