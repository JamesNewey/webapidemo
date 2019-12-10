using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPIDemo.Core.Types
{
    public class Album
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public IEnumerable<Photo> Photos { get; set; }
    }
}
