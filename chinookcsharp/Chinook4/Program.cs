using Chinook4.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook4
{
    class Program
    {
        static void Main(string[] args)
        {
            ChinookEntities context = new ChinookEntities();
            List<Album> albums = context.Albums.ToList();
            foreach (var item in albums)
            {
                Console.WriteLine(item.AlbumId);
            }

            List<Track> tracks = context.Tracks.ToList();
            var query = from t in tracks
                        join a in albums on t.AlbumId equals a.AlbumId
                        select new { t.TrackId, t.AlbumId, a.Title };
            var list = query.ToList();
            foreach (var item in list)
            {
                Console.WriteLine($"==={item.TrackId} / {item.AlbumId} / {item.Title}");
            }
        }
    }
}
