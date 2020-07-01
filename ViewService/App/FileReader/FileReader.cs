using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ViewService.App
{
    public class FileReader
    {
        public static async Task<string> ReadFileAsStringAsync(string path)
        {
            try
            {
                return await File.ReadAllTextAsync(path);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
