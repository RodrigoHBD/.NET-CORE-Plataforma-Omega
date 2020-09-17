using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.UseCases
{
    public class MessageUseCases
    {
        public static SendMessage SendMessage { get { return new SendMessage(); } }
    }
}
