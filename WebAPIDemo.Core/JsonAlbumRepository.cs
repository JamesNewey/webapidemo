using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebAPIDemo.Core.Types.Dto;

namespace WebAPIDemo.Core
{
    /// <summary>
    /// The album and photo repository.
    /// </summary>
    public class JsonAlbumRepository : IAlbumRepository
    {
        private readonly IHttpUtility httpUtility;
        private readonly string albumsPath;
        private readonly string photosPath;

        public JsonAlbumRepository(IHttpUtility utility, string albums, string photos)
        {
            if (string.IsNullOrEmpty(albums) || string.IsNullOrEmpty(photos))
                throw new InvalidOperationException("No url(s) specified for json albums/photos");

            httpUtility = utility;
            albumsPath = albums;
            photosPath = photos;
        }

        /// <summary>
        /// Returns the albums from the given store.
        /// </summary>
        /// <returns>The task object representing the albums returned.</returns>
        public async Task<IEnumerable<AlbumDto>> GetAlbumsAsync()
        {
            string data = await httpUtility.FetchAddressAsync(albumsPath);

            return JsonConvert.DeserializeObject<List<AlbumDto>>(data);
        }

        /// <summary>
        /// Returns the photos from the given store.
        /// </summary>
        /// <returns>The task object representing the photos returned.</returns>
        public async Task<IEnumerable<PhotoDto>> GetPhotosAsync()
        {
            string data = await httpUtility.FetchAddressAsync(photosPath);

            return JsonConvert.DeserializeObject<List<PhotoDto>>(data);
        }
    }
}
