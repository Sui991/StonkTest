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
            model_Create model_crate = new model_Create();
        
            return View();
        }
        [HttpPost]
        public ActionResult Create(model_Create model_crate)
        {
            model_crate.Create();
            
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
            model_edit.Delete();
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

            model_edit.edit();

            return RedirectToAction("Index");
        }
    }
}

