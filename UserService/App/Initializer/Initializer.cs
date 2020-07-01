using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserService.App
{
    public class AppInitializer
    {
        public static async Task InitializeAsync()
        {
            try
            {
                await InitializeDatabaseAsync();
                InitializeRoutines();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static async Task InitializeDatabaseAsync()
        {
            try
            {
                await Database.Connect();
                await Collections.InitializeAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void InitializeRoutines()
        {
            try
            {
               
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
