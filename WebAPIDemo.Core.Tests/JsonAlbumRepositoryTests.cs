using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIDemo.Core.Types;
using WebAPIDemo.Core.Types.Dto;

namespace WebAPIDemo.Core.Tests
{
    [TestFixture]
    public class JsonAlbumRepositoryTests
    {
        private const string albumUrl = "albumUrl";
        private const string photoUrl = "photoUrl";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAlbumsAsync_AlbumsAvailable_AlbumsReturned()
        {
            var httpUtilityMock = new Mock<IHttpUtility>();
            string albumTestData = "[{ \"userId\" : 1, \"albumId\": 1, \"title\": \"Test Album\" }]";
            httpUtilityMock.Setup(m => m.FetchAddressAsync(albumUrl)).ReturnsAsync(() => albumTestData);

            var repository = new JsonAlbumRepository(httpUtilityMock.Object, albumUrl, photoUrl);

            var task = repository.GetAlbumsAsync();
            var albumResult = task.Result.ToList();
            Assert.AreEqual(1, albumResult.Count());
            Assert.AreEqual("Test Album", albumResult[0].Title);
            Assert.AreEqual(1, albumResult[0].UserId);
        }

        [Test]
        public void GetPhotosAsync_PhotosAvailable_AlbumsReturned()
        {
            var httpUtilityMock = new Mock<IHttpUtility>();
            string photoTestData = "[{ \"id\" : 1, \"albumId\": 1, \"title\": \"Test Photo\" }]";
            httpUtilityMock.Setup(m => m.FetchAddressAsync(photoUrl)).ReturnsAsync(() => photoTestData);

            var repository = new JsonAlbumRepository(httpUtilityMock.Object, albumUrl, photoUrl);

            var task = repository.GetPhotosAsync();
            var photoResult = task.Result.ToList();
            Assert.AreEqual(1, photoResult.Count());
            Assert.AreEqual("Test Photo", photoResult[0].Title);
            Assert.AreEqual(1, photoResult[0].Id);
            Assert.AreEqual(1, photoResult[0].AlbumId);
        }
    }
}