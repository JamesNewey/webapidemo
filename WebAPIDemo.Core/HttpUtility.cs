using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core
{
    public class HttpUtility : IHttpUtility
    {
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
