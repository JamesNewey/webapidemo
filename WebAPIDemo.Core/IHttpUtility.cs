using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIDemo.Core
{
    public interface IHttpUtility
    {
        Task<string> FetchAddressAsync(string requestUrl);
    }
}
