using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core
{
    /// <summary>
    /// HTTP utility class.
    /// </summary>
    public class HttpUtility : IHttpUtility
    {
        /// <summary>
        /// Fetch the contents of a url using HTTP.
        /// </summary>
        /// <param name="requestUrl">The request url.</param>
        /// <returns>The task object representing the contents of the url.</returns>
        public async Task<string> FetchAddressAsync(string requestUrl)
        {
            string data = null;
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync(requestUrl))
                {
                    using (var content = response.Content)
                    {
                        data = await content.ReadAsStringAsync();
                    }
                }
            }
            return data;
        }
    }
}
