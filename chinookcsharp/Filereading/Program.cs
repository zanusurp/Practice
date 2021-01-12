using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filereading
{
    class Program
    {
        static void Main(string[] args)
        {
            //WriteText();
            //ReadText();
            //WriteBinary();
            //ReadBinary();
            //WritePlatoon();
            //ReadPlatoon();
            Get1();
            Insert();
        }

        private static void Insert()
        {
            Artist artist = new Artist();
            artist.ArtistId = 123;
            artist.Name = "Thomas";
            
            ChinookEntities context = new ChinookEntities();
            Console.WriteLine(context.Artists.Count());
            context.Database.Log = PrintSQL;
            context.Artists.Add(artist);
            context.SaveChanges();
            

            Console.WriteLine(artist.ArtistId);
            Console.WriteLine(context.Artists.Count());
        }

        private static void Get1()
        {
            ChinookEntities context = new ChinookEntities();
            context.Database.Log = PrintSQL;
            Album album = context.Albums.FirstOrDefault(x=>x.AlbumId ==3);
            Console.WriteLine(album.AlbumId + " / " + album.Title);

            Album a1 = context.Albums.Where(x => x.AlbumId > 100).FirstOrDefault();
            var query = from x in context.Albums where x.AlbumId > 100 select x;
            List<Album> albums = query.ToList();
            Album a2 = query.FirstOrDefault();

        }

        private static void PrintSQL(string sql)
        {
            Console.WriteLine(sql);
        }

        private static void ReadPlatoon()
        {
            string json = File.ReadAllText(@"d:\gitclone\chigit\chinookcsharp\Filereading\platoontext.json");
            Platoon  platoon = JsonConvert.DeserializeObject<Platoon>(json);

            foreach (var item in platoon.Marines)
            {
                Console.WriteLine(item.No);
            }
            foreach (var item in platoon.Firebats)
            {
                Console.WriteLine(item.No);
            }
        }

        private static void WritePlatoon()
        {
            Platoon platoon = new Platoon();
            platoon.Marines.Add(new Marine(1));
            platoon.Marines.Add(new Marine(2));
            platoon.Firebats.Add(new Firebat(1));
            platoon.Firebats.Add(new Firebat(2));
            platoon.Firebats.Add(new Firebat(3));
            //json
            string json = JsonConvert.SerializeObject(platoon);
            Console.WriteLine(json);
            File.WriteAllText(@"d:\gitclone\chigit\chinookcsharp\Filereading\platoontext.json", json);
        }

        private static void ReadBinary()
        {
            byte[] bytes = File.ReadAllBytes(@"d:\gitclone\chigit\chinookcsharp\Filereading\binary");
            int data = BitConverter.ToInt32(bytes,0);
            Console.WriteLine(data);
        }

        private static void WriteBinary()
        {
            byte[] bytes = BitConverter.GetBytes(3512);
            File.WriteAllBytes(@"d:\gitclone\chigit\chinookcsharp\Filereading\binary", bytes);
        }

        private static void ReadText()
        {
            String data = File.ReadAllText(@"d:\gitclone\chigit\chinookcsharp\Filereading\text");
            Console.WriteLine(data);
        }

        private static void WriteText()
        {
            File.WriteAllText(@"d:\gitclone\chigit\chinookcsharp\Filereading\text", "1232224");
        }
    }
}
