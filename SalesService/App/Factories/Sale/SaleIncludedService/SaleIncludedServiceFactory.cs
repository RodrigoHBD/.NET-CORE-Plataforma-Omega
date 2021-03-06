﻿using SalesService.App.Models;
using SalesService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Factories
{
    public class SaleIncludedServiceFactory
    {
        public static SaleIncludedService MakeIncludedService(SaleIncludedService service)
        {
            try
            {
                return new SaleIncludedService()
                {
                    Name = service.Name,
                    Description = service.Description,
                    Value = service.Value
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
