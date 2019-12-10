using System;
using System.Collections.Generic;
using System.Text;
using WebAPIDemo.Core.Types;
using System.Threading.Tasks;
using System.Linq;

namespace WebAPIDemo.Core
{
    public class AlbumService : IAlbumService
    {
        IAlbumRepository albumRepository;

        public AlbumService(IAlbumRepository repository)
        {
            albumRepository = repository;
        }

        public async Task<IEnumerable<Album>> GetAlbums()
        {
            var albums = await GetAlbumsFromRepository();

            return albums;
        }

        public async Task<IEnumerable<Album>> GetAlbumsByUserId(int userId)
        {
            var albums = await GetAlbumsFromRepository();

            return albums.Where(a => a.UserId == userId);
        }

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
