using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinook.cui
{
    class Program
    {
        static void Main(string[] args)
        {
            AlbumData data = new AlbumData();
            Console.WriteLine(data.getCount());

            Album album = data.SelectById(12);
            Console.WriteLine(album.ToText());

            List<Album> list = data.Select();
            //foreach (var item in list)
            //{
            //    Console.WriteLine(item.ToText());
            //}

            list = list.FindAll(x => x.Title.Contains("road"));
            foreach (var item in list)
            {
                Console.WriteLine(item.ToText());
            }
        }
    }
}
