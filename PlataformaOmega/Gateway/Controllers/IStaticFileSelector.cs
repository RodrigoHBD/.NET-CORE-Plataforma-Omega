using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public class StaticFileSelector
    {
        private string _Path { get; set; }
        public string Path { get { return $"\\Assets\\{_Path}"; } set { _Path = value; } }
        public StaticFileSelector(string path)
        {
            Path = path;
        }
    }

    
}
