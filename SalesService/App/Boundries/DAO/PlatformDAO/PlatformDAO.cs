using SalesService.App.Boundries.PlatformDAOQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries
{
    public class PlatformDAO
    {
        public static Queries Queries { get; set; } = new Queries();

        public static async Task<bool> CheckIfExistsByName (string name)
        {
            try
            {
                var count = await Queries.Count.Execute(name);
                var exists = count > 0;
                return exists;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
