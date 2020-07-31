using MongoDB.Driver;
using SalesService.ServerGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesService.App.Boundries.PlatformDAOQueries
{
    public class CountByName
    {
        public async Task<long> Execute(string name)
        {
			try
			{
				var filter = Builders<Platform>.Filter.Where(platform => platform.Name == name);
				return await Collections.Platforms.CountDocumentsAsync(filter);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
