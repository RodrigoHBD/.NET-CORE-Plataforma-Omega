using ProductService.App.Entities;
using ProductService.App.Models;
using ProductService.App.Models.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductService.App.Factories
{
    public class BrandFactory
    {
        public static Brand MakeBrand(IRegisterNewBrandRequest request)
        {
            try
            {
                return new Brand()
                {
                    Name = request.Name,
                    Abbreviation = request.Abbreviation,
                    Cnpj = BrandEntity.NormilizeCnpj(request.Cnpj)
                };
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
