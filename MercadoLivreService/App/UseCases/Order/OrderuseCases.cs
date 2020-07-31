using MercadoLivreService.App.UseCases.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MercadoLivreService.App.UseCases
{
    public class OrderUseCases
    {
        public static GetDetails GetDetails { get; } = new GetDetails();
    }
}
