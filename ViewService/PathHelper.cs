using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ViewService.App
{
    public class PathHelper
    {
        public static string ViewsFolderPath { get; } = $"{Directory.GetCurrentDirectory()}\\Files\\Views";
        public static string StaticFilesFolderPath { get; } = $"{Directory.GetCurrentDirectory()}\\Files\\Static";
    }
}
