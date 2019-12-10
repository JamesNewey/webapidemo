using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.Core.Types.Dto
{
    public class PhotoDto
    {
        public int AlbumId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
