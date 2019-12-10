using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Core.Types;
using WebAPIDemo.Core.Types.Dto;

namespace WebAPIDemo.Core.Tests
{
    [TestFixture]
    public class AlbumServiceTests
    {
        List<AlbumDto> albumTestData = new List<AlbumDto>
        {
            new AlbumDto() { Id = 1, Title = "Test", UserId = 1 },
            new AlbumDto() { Id = 2, Title = "Another Test", UserId = 1 },
            new AlbumDto() { Id = 3, Title = "Album diff user", UserId = 2 }
        };

        List<PhotoDto> photoTestData = new List<PhotoDto>
        {
            new PhotoDto() { Id = 1, AlbumId = 1, Title = "Test1" },
            new PhotoDto() { Id = 2, AlbumId = 1, Title = "Test2" },
            new PhotoDto() { Id = 3, AlbumId = 1, Title = "Test3" },
            new PhotoDto() { Id = 4, AlbumId = 2, Title = "Test4" },
            new PhotoDto() { Id = 5, AlbumId = 2, Title = "Test5" },
            new PhotoDto() { Id = 6, AlbumId = 3, Title = "Test6" }
        };

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAlbums_AlbumsAvailable_AlbumsReturned()
        {
            var jsonAlbumRepoMock = new Mock<IAlbumRepository>();

            jsonAlbumRepoMock.Setup(m => m.GetAlbumsAsync()).ReturnsAsync(() => albumTestData);
            jsonAlbumRepoMock.Setup(m => m.GetPhotosAsync()).ReturnsAsync(() => photoTestData);

            var service = new AlbumService(jsonAlbumRepoMock.Object);

            var task = service.GetAlbums();

            var albumsResult = task.Result.ToList();

            Assert.AreEqual(3, albumsResult.Count);
            Assert.AreEqual("Test", albumsResult[0].Title);
            Assert.AreEqual(3, albumsResult[0].Photos.Count());
            Assert.AreEqual("Test1", ((List<Photo>)albumsResult[0].Photos)[0].Title);
            Assert.AreEqual("Test2", ((List<Photo>)albumsResult[0].Photos)[1].Title);
            Assert.AreEqual("Test3", ((List<Photo>)albumsResult[0].Photos)[2].Title);
            Assert.AreEqual("Another Test", albumsResult[1].Title);
            Assert.AreEqual(2, albumsResult[1].Photos.Count());
            Assert.AreEqual("Test4", ((List<Photo>)albumsResult[1].Photos)[0].Title);
            Assert.AreEqual("Test5", ((List<Photo>)albumsResult[1].Photos)[1].Title);
            Assert.AreEqual("Album diff user", albumsResult[2].Title);
            Assert.AreEqual(1, albumsResult[2].Photos.Count());
            Assert.AreEqual("Test6", ((List<Photo>)albumsResult[2].Photos)[0].Title);
        }

        [Test]
        public void GetAlbums_NoAlbumsAvailable_NoAlbumsReturned()
        {
            var jsonAlbumRepoMock = new Mock<IAlbumRepository>();

            jsonAlbumRepoMock.Setup(m => m.GetAlbumsAsync()).ReturnsAsync(() => new List<AlbumDto>());

            var service = new AlbumService(jsonAlbumRepoMock.Object);

            var task = service.GetAlbums();

            var albumsResult = task.Result.ToList();

            Assert.AreEqual(0, albumsResult.Count);
        }

        [Test]
        public void GetAlbumsByUserId_AlbumsMatchRequestedUserId_MatchingAlbumsReturned()
        {
            var jsonAlbumRepoMock = new Mock<IAlbumRepository>();

            jsonAlbumRepoMock.Setup(m => m.GetAlbumsAsync()).ReturnsAsync(() => albumTestData);
            jsonAlbumRepoMock.Setup(m => m.GetPhotosAsync()).ReturnsAsync(() => photoTestData);

            var service = new AlbumService(jsonAlbumRepoMock.Object);

            var task = service.GetAlbumsByUserId(1);

            var albumsResult = task.Result.ToList();

            Assert.AreEqual(2, albumsResult.Count);
            Assert.AreEqual("Test", albumsResult[0].Title);
            Assert.AreEqual("Another Test", albumsResult[1].Title);
        }
    }
}