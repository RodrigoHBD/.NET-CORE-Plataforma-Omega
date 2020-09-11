using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class JsonDeserializationAttempt
    {
        public bool ThrewException { get; set; }
        public Exception Exception { get; set; }
        public dynamic Data { get; set; }
    }
}
