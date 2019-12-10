using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Types;

namespace WebAPIDemo.Core
{
    public interface IAlbumService
    {
        Task<IEnumerable<Album>> GetAlbums();

        Task<IEnumerable<Album>> GetAlbumsByUserId(int userId);
    }
}
