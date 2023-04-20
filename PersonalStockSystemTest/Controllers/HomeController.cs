using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalStockSystemTest.Models;
namespace PersonalStockSystemTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBmanager dbmanager = new DBmanager();
            var stonks = dbmanager.GetStonks();
            ViewBag.stonks = stonks;
            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}