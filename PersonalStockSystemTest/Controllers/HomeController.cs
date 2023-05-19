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


namespace PersonalStockSystemTest.Controllers
{
    public class HomeController : Controller
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
       
        public ActionResult Search()
        {
     
            model_List model_List = new model_List();
            model_List.Init();
            return View(model_List);
        }
        [HttpPost]
        public ActionResult Search(model_List model_List)
        {
            model_List.Search();
            return View(model_List);
        }
        public ActionResult Create()
        {
            //DBmanager dbmanager = new DBmanager();
            ////var stonks = dbmanager.GetStonks();
            //CRUD stonks = new CRUD();
            //stonks.Search(id);
            model_List model_List = new model_List();
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(model_List model_List)
        {
            model_List.Create();
            
            return View();
        }
        public ActionResult Delete(int? id)
        {
            model_List model_List = new model_List();
            model_List.Delete(id);
            return View(model_List);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteComfirmed(int? id)
        {
            model_List model_List = new model_List();
            model_List.Delete(id);
            return View(model_List);
        }
        public ActionResult Edit(int id)
        {
            model_List model_List = new model_List();
        
            model_List.Edit(id);
            return View(model_List);
        }
        [HttpPost]
        public ActionResult Edit(int id, model_List model_List)
        {

            model_List.Edit(id);
            
            return View(model_List);
        }
    }
}

