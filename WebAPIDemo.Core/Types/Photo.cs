using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.Core.Types
{
    public class Photo
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public string ThumbnailUrl { get; set; }
    }
}
