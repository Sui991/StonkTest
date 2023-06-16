using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PersonalStockSystemTest.Models;
using PersonalStockSystemTest.EFModel;
using System.Threading.Tasks;
using System.IO;
using HtmlAgilityPack;
using System.Text;


namespace PersonalStockSystemTest.Controllers
{
    public class StonkTablesController : Controller
    {
        StonkDBEntities db = new StonkDBEntities();
        public ActionResult Index()
        {
            DBmanager dbmanager = new DBmanager();
            var stonks = dbmanager.GetStonks();
            ViewBag.stonks = stonks;
            model_List model_List = new model_List();
            model_List.Init();
            return View(model_List);


        }
        public static bool isValidURL(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse;
            try
            {
                webResponse = webRequest.GetResponse();
            }
            catch //If exception thrown then couldn't get response from address
            {
                return false;
            }
            return true;
        }
        public JsonResult GetCrawler(int id)
        {
            model_List model = new model_List();
            var stonkID = id.ToString();
            return Json(data: model.GetPythonJson(stonkID), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Test()
        //{
        //    Crawler model = new Crawler();
        //    string SourceURL_1 = "http://www.coolpc.com.tw/evaluate.phpsdfsdfanlksjfiojsidhfsdfsdfsdfsdf";
        //    string SourceURL_2 = "https://www.cnyes.com/twstock/2330";


        //    string Endpoint = "";
        //    if (isValidURL(SourceURL_1))
        //    {
        //        model.dataSource = "目前使用第一個資料來源";
        //        Endpoint = SourceURL_1;
        //    }
        //    else if (isValidURL(SourceURL_2))
        //    {
        //        model.dataSource = "目前使用第二個資料來源~";
        //        Endpoint = SourceURL_2;
        //    }
        //    else
        //    {
        //        model.dataSource = "兩個資料來源都掛惹~ zzz";
        //    }
        //    //-----------------------------------------------------------------------------------------
        //    WebClient url = new WebClient();
        //    //Note: 將網頁來源資料暫存到記憶體內
        //    MemoryStream ms = new MemoryStream(url.DownloadData(Endpoint));
        //    //Note: 使用預設編碼讀入 HTML  ,此為第三方套件 HtmlAgilityPack
        //    HtmlDocument doc = new HtmlDocument();
        //    doc.Load(ms, Encoding.Default);
        //   //*********************************
        //   //< h3 class="jsx-162737614 rise">30.25</h3>
        //    var priceNode = doc.DocumentNode.SelectSingleNode("//h3[@class='jsx-162737614 rise']");
        //    if (priceNode != null)
        //    {
        //        string priceText = priceNode.InnerText;
        //        model.data1 = priceText;
        //    }
        //    else if (priceNode == null)
        //    {
        //         priceNode = doc.DocumentNode.SelectSingleNode("//h3[@class='jsx-162737614 fall']");
        //        string priceText = priceNode.InnerText;
        //        model.data1 = priceText;
        //    }
        //    else
        //    {
        //        model.data1 = "無法獲取股票價格";
        //    }
        //    TempData["data1"]= model.data1;
        //    return View(model);
        //}

        public ActionResult Search()
        {
     
            model_List model_List = new model_List();
            model_List.Init();
            //----------爬蟲----------------
          
            return View(model_List);

        }
        [HttpPost]
        public ActionResult Search(model_List model_List)
        {          
            TempData["Msg"] = model_List.Search();
            TempData["StonkID"] = model_List.GetID();
            

            //Crawler model = new Crawler();  
            //string SourceURL_1 = "http://www.coolpc.com.tw/evaluate.phpsdfsdfanlksjfiojsidhfsdfsdfsdfsdf";
            //string SourceURL_2 = $"https://www.cnyes.com/twstock/{key}";


            //string Endpoint = "";
            //if (isValidURL(SourceURL_1))
            //{
            //    model.dataSource = "目前使用第一個資料來源";
            //    Endpoint = SourceURL_1;
            //}
            //else if (isValidURL(SourceURL_2))
            //{
            //    model.dataSource = "目前使用第二個資料來源~";
            //    Endpoint = SourceURL_2;
            //}
            //else
            //{
            //    model.dataSource = "兩個資料來源都掛惹~ zzz";
            //}
            ////-----------------------------------------------------------------------------------------
            //WebClient url = new WebClient();
            ////Note: 將網頁來源資料暫存到記憶體內
            //MemoryStream ms = new MemoryStream(url.DownloadData(Endpoint));
            ////Note: 使用預設編碼讀入 HTML  ,此為第三方套件 HtmlAgilityPack
            //HtmlDocument doc = new HtmlDocument();
            //doc.Load(ms, Encoding.Default);
            ////*********************************
            ////< h3 class="jsx-162737614 rise">30.25</h3>
            //var priceNode = doc.DocumentNode.SelectSingleNode("//h3[@class='jsx-162737614 rise']");
            //if (priceNode != null)
            //{
            //    string priceText = priceNode.InnerText;
            //    model.data1 = priceText;
            //}
            //else if (priceNode == null)
            //{
            //    priceNode = doc.DocumentNode.SelectSingleNode("//h3[@class='jsx-162737614 fall']");
            //    string priceText = priceNode.InnerText;
            //    model.data1 = priceText;
            //}
            //else
            //{
            //    model.data1 = "無法獲取股票價格";
            //}
            //TempData["data1"] = model.data1;
            TempData["Msg"] = model_List.Search();
            return View(model_List);
        }
        public ActionResult Create()
        {
            //DBmanager dbmanager = new DBmanager();
            ////var stonks = dbmanager.GetStonks();
            //CRUD stonks = new CRUD();
            //stonks.Search(id);
            model_Create model_crate = new model_Create();
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(model_Create model_crate)
        {
            TempData["Msg"] = model_crate.Create();
            
            return View();
        }
        public ActionResult Delete(int id)
        {
            model_Edit model_Delete = new model_Edit();
            model_Delete.Load(id);
            return View(model_Delete);
        }
        [HttpPost]
        public ActionResult Delete(model_Edit model_edit)
        {
           
            TempData["Msg"] = model_edit.Delete();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            model_Edit model_edit = new model_Edit();
            model_edit.Load(id);
            return View(model_edit);
        }
        [HttpPost]
        public ActionResult Edit(model_Edit model_edit)
        {

            TempData["Msg"] = model_edit.edit();
            return RedirectToAction("Index");
        }
    }
}

