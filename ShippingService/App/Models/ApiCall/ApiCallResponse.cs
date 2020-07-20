using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShippingService.App.Models
{
    public class ApiCallResponse
    {
        public bool IsDeserializedWithDataModel { get; set; } = false;
        public bool IsDeserializedWithErrorModel { get; set; } = false;
        public bool HasDeserializationException { get; set; } = false;
        public dynamic JsonData { get; set; } = null;
        public Exception DeserializationException { get; set; } = null;
    }

}
