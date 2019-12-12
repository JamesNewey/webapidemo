using System;
using System.Collections.Generic;
using System.Text;
using WebAPIDemo.Core.Types;
using System.Threading.Tasks;
using System.Linq;

namespace WebAPIDemo.Core
{
    /// <summary>
    /// Album service for fetching album data.
    /// </summary>
    public class AlbumService : IAlbumService
    {
        IAlbumRepository albumRepository;

        public AlbumService(IAlbumRepository repository)
        {
            albumRepository = repository;
        }

        /// <summary>
        /// Get a list of all albums.
        /// </summary>
        /// <returns>The task object representing the list of albums.</returns>
        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await GetAlbumsFromRepository();

            return albums;
        }

        /// <summary>
        /// Get a list of albums by user Id.
        /// </summary>
        /// <param name="userId">The user Id.</param>
        /// <returns>The list of albums matching the user Id.</returns>
        public async Task<IEnumerable<Album>> GetAlbumsByUserId(int userId)
        {
            var albums = await GetAlbumsFromRepository();

            return albums.Where(a => a.UserId == userId);
        }

        /// <summary>
        /// Get the albums from the album repository.
        /// </summary>
        /// <returns>The albums returned from the repository.</returns>
        private async Task<IEnumerable<Album>> GetAlbumsFromRepository()
        {
            var albums = await albumRepository.GetAlbumsAsync();
            var photos = await albumRepository.GetPhotosAsync();

            return albums.Select(albumDto => new Album()
            {
                Id = albumDto.Id,
                UserId = albumDto.UserId,
                Title = albumDto.Title,
                Photos = photos.Where(p => p.AlbumId == albumDto.Id).Select(photoDto => new Photo()
                {
                    Id = photoDto.Id,
                    Title = photoDto.Title,
                    Url = photoDto.Url,
                    ThumbnailUrl = photoDto.ThumbnailUrl
                }).ToList()
            });
        }
    }
}
