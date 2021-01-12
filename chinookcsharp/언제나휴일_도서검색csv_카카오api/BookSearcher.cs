using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace 언제나휴일_도서검색csv_카카오api
{
    public static class BookSearcher
    {
        static Dictionary<string, Book> book_dic = new Dictionary<string, Book>();
        static string url = "https://dapi.kakao.com/v3/search/book";
        static string rkey = "75cd4e264e614f296e8bdf6d45fefc72";

        public static List<Book> Search(string text)
        {
            List<Book> books = new List<Book>();
            string query_str = string.Format("{0}?target=title&query={1}", url, text);
            WebRequest req = WebRequest.Create(query_str);
            req.Headers.Add("Authorization", "KakaoAK "+rkey); //스페이스 공간 꼭 확보
            WebResponse res = req.GetResponse();
            Stream stream = res.GetResponseStream();
            StreamReader sr = new StreamReader(stream);
            string result = sr.ReadToEnd();

            JavaScriptSerializer jss = new JavaScriptSerializer();
            dynamic dres = jss.Deserialize<dynamic>(result);
            dynamic ddoc = dres["documents"];
            object[] dbooks = ddoc;

            Book book;
            for (int i = 0; i < dbooks.Length; i++) 
            {
                book = MakeBook(dbooks[i]);
                if (book_dic.ContainsKey(book.ISBN) == false)
                {
                    book_dic[book.ISBN] = book;
                    books.Add(book);
                }

            }
            return books;

        }

        private static Book MakeBook(dynamic dbook)
        {
            string isbn = dbook["isbn"];
            string title = dbook["title"];
            title = title.Replace(",", " ");
            string author = dbook["authors"][0];
            author = author.Replace(",", " ");
            return new Book(title, isbn, author);
        }
        public static void Save()
        {
            FileStream fs = File.Create("book.csv");
            StreamWriter sw = new StreamWriter(fs);
            foreach (Book book in book_dic.Values)
            {
                sw.WriteLine("{0},{1},{2}", book.Title, book.ISBN, book.Author);
            }
            sw.Close();
            fs.Close();
        }public static List<Book> Load()
        {
            List<Book> books = new List<Book>();
            if (File.Exists("book.csv"))
            {
                FileStream fs = File.OpenRead("book.csv");
                StreamReader sr = new StreamReader(fs);
                while(sr.EndOfStream == false)
                {
                    string s = sr.ReadLine();
                    string[] sdatas = s.Split(',');
                    Book book = new Book(sdatas[0], sdatas[1], sdatas[2]);
                    books.Add(book);
                    book_dic[book.ISBN] = book;
                }
                sr.Close();
                fs.Close();
            }
            return books;
        }
    }
}
