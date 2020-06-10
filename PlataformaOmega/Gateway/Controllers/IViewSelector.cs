using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gateway.Controllers
{
    public interface IViewSelector
    {
        string Path { get; }
    }

    public class AppViewSelector : IViewSelector
    {
        public string Path { get; } = "\\SPA\\index.html";
    }
}
