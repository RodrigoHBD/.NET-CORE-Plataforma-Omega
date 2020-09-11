using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HttpClientLibrary
{
    public class HttpClientLib
    {
        public static async Task<DataType> Get<DataType, ErrorType>(GetRequest req)
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

		public static async Task<DataType> Post<DataType, ErrorType>(PostRequest req)
        {
			try
			{
				var response = await HttpRequester.PostAsync(req);
				return ResponseHandler.HanldeResponse<DataType, ErrorType>(response);
			}
			catch (Exception)
			{
				throw;
			}
		}

	}
}
