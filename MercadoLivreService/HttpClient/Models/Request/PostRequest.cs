using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class PostRequest : HttpRequest
    {
        public dynamic Data { get; set; }
    }
}
