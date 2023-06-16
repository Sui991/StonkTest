using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using HtmlAgilityPack;
using System.Threading.Tasks;
using AngleSharp;
using AngleSharp.Io;
using LINQPad;
using System.Net;

namespace PersonalStockSystemTest.Models
{
    public class Crawler
    {

        public int Price { get; set; }
        public string Link { get; set; }
        public string dataSource { get; set; }
        public string data1 { get; set; }
    }
    public class Product
    {
        public string type { get; set; }
        public string name { get; set; }
    }
    //public async Task Main()
    //{
    //    var key = "2330";
    //    var url = $"https://www.cnyes.com/twstock/{key}";

    //    var config = AngleSharp.Configuration.Default.WithDefaultLoader(
    //    new LoaderOptions
    //    {
    //        IsResourceLoadingEnabled = true
    //    });

    //    var browser = BrowsingContext.New(config);

    //    var document = await browser.OpenAsync(url);
    //    var tables = document?.QuerySelectorAll("div.container:nth-child(2) > div:nth-child(2)");
    //    document.Close();

    //var TableData=tables.ToDictionary(
    //        t => t.FirstChild.TextContent, // 欄位名稱 ex: 開盤價
    //        t => t.LastChild.TextContent)  // 欄位數值 ex: 500
    //    .Dump();
    //}


    //static void Main(string[] args)
    //{
    //    var url = "https://www.cnyes.com/twstock/2330";

    //    HtmlWeb web = new HtmlWeb();
    //    HtmlDocument doc = web.Load(url);

    //    // 使用 XPath 選擇所需的元素，這裡以選擇股價元素為例
    //    var priceElement = doc.DocumentNode.SelectSingleNode("//div[@id='stock-price']");

    //    if (priceElement != null)
    //    {
    //        var price = priceElement.InnerText;
    //        // 在此進行後續的運算或其他處理

    //        // 將結果傳送給前端，可以使用 API 或其他方式
    //    }
    //}

    //static async System.Threading.Tasks.Task Main(string[] args)
    //{
    //    設定目標網站的 URL
    //    string url = "https://www.cnyes.com/";

    //    建立 HttpClient 物件
    //    using (HttpClient client = new HttpClient())
    //    {
    //        發送 GET 請求並取得回應
    //       HttpResponseMessage response = await client.GetAsync(url);
    //        if (response.IsSuccessStatusCode)
    //        {
    //            讀取回應內容
    //            string htmlContent = await response.Content.ReadAsStringAsync();

    //            使用 HtmlAgilityPack 解析 HTML
    //            HtmlDocument htmlDoc = new HtmlDocument();
    //            htmlDoc.LoadHtml(htmlContent);

    //            撰寫程式碼來定位和擷取你需要的資訊
    //            例如，以下程式碼會抓取鉅亨網首頁的標題
    //           HtmlNode titleNode = htmlDoc.DocumentNode.SelectSingleNode("//title");
    //            string title = titleNode.InnerText;

    //            輸出結果
    //            Console.WriteLine("Title: " + title);
    //        }
    //        else
    //        {
    //            Console.WriteLine("HTTP Request Error: " + response.StatusCode);
    //        }
    //    }
    //}
}
