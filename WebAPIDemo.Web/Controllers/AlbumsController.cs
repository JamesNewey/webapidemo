using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPIDemo.Core;
using WebAPIDemo.Core.Types;

namespace WebAPIDemo.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlbumsController : ControllerBase
    {
        IAlbumService albumService;

        private readonly ILogger<AlbumsController> _logger;

        public AlbumsController(ILogger<AlbumsController> logger, IAlbumService service)
        {
            _logger = logger;
            albumService = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAllAlbums()
        {
            var albums = await albumService.GetAlbums();

            if (!albums.Any())
                return NotFound();

            return Ok(albums);
        }

        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByUserId(int userId)
        {
            var albums = await albumService.GetAlbumsByUserId(userId);

            if (!albums.Any())
                return NotFound();

            return Ok(albums);
        }
    }
}
