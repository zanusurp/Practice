using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient web = new WebClient();
            web.Encoding = Encoding.UTF8;

            int pageNo = 100;
            String url = $"http://m.finance.daum.net/m/item/item_daily.daum?code=005930&page={pageNo}";

            String html = web.DownloadString(url);
            Console.WriteLine(html);

            List<Price> prices = new List<Price>();

            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.LoadHtml(html);
            HtmlNode root = document.DocumentNode;

            HtmlNode th  =root.SelectSingleNode("//*[@id=\"mArticle\"]/div/table/tbody/tr[1]/th");

            String dateText = th.InnerText;
            DateTime date = DateTime.ParseExact(dateText, "yy.MM.dd", null);

            HtmlNode tr = root.SelectSingleNode("//*[@id=\"mArticle\"]/div/table/tbody/tr[1]/tr");
            string valueText = tr.InnerText;
            int value = int.Parse(valueText);

            HtmlNode tbody = root.SelectSingleNode("//*[@id=\"mArticle\"]/div/table/tbody");
            var trs = tbody.ChildNodes.Where(x => x.Name == "tr");

            List<Price> prices1 = new List<Price>();

            foreach (var item in trs)
            {
                Price price = new Price();

                HtmlNode th1 = item.FirstChild;
                string dateText1 = th1.InnerText;
                DateTime date1 = DateTime.ParseExact(dateText1, "yy.MM.dd", null);

                price.Date = date1; 

                HtmlNode td1 = item.ChildNodes[1];
                string valueText1 = td1.InnerText;
                int value1 = int.Parse(valueText1,System.Globalization.NumberStyles.Number);
                price.Value = value1;

                prices1.Add(price);
            }
            foreach (var item in prices1)
            {
                Console.WriteLine($"{item.Date} / {item.Value}");
            }


        }
    }
}
