using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class HttpClientLib
    {
        public static async Task<DataType> GetDeserializedJson<DataType, ErrorType>(GetRequest req)
        {
			try
			{
				var response = await HttpRequester.GetAsync(req);
				return ResponseHandler.HanldeResponse<DataType, ErrorType>(response);
			}
			catch (Exception)
			{
				throw;
			}
        }
    }
}
