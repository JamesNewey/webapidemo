using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIDemo.Core.Types.Dto;

namespace WebAPIDemo.Core
{
    public interface IAlbumRepository
    {
        Task<IEnumerable<AlbumDto>> GetAlbumsAsync();

        Task<IEnumerable<PhotoDto>> GetPhotosAsync();
    }
}
