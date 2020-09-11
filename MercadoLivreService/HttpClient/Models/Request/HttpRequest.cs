using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class HttpRequest
    {
        public string Uri { get; set; }
        public List<UriParam> Params { get; set; }
    }
}
