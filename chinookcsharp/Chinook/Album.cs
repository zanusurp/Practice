using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }

        public string ToText(string decorator= "^")
        {
            return $"{decorator}{AlbumId}/{Title}/{ArtistId}{decorator}";
        }
    }
}
