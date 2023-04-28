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
            return View();
        

        }
        [HttpPost]
        public ActionResult
        Index(int? id)
        {
            {
               
                if (id == null)
                {
                   return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                StonkTable stonkTable = db.StonkTable.Find(id);
                if (stonkTable == null)
                {
                    return HttpNotFound();
                }
                return View(stonkTable);
            }
             //DBmanager dbmanager = new DBmanager();
                //var stonks = dbmanager.GetStonks();
                //ViewBag.stonks = stonks;
                //var result = from m in db.StonkTable select m;
                // result = result.Where(s => s.stonkID.HasValue);
                //    if (result != null)
                //   {
                     
                //       db.SaveChanges();
                      
                //      return View(result);
                //   }
                // else
                //     return View();
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
        // GET: StonkTables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StonkTable stonkTable = db.StonkTable.Find(id);
            if (stonkTable == null)
            {
                return HttpNotFound();
            }
            return View(stonkTable);
        }

        // GET: StonkTables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StonkTables/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,stonkID,type,time,num,price,tax,fax,initDate,total")] StonkTable stonkTable)
        {
            if (ModelState.IsValid)
            {
                db.StonkTable.Add(stonkTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stonkTable);
        }

        // GET: StonkTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StonkTable stonkTable = db.StonkTable.Find(id);
            if (stonkTable == null)
            {
                return HttpNotFound();
            }
            return View(stonkTable);
        }

        // POST: StonkTables/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,stonkID,type,time,num,price,tax,fax,initDate,total")] StonkTable stonkTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stonkTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stonkTable);
        }

        // GET: StonkTables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StonkTable stonkTable = db.StonkTable.Find(id);
            if (stonkTable == null)
            {
                return HttpNotFound();
            }
            return View(stonkTable);
        }

        // POST: StonkTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StonkTable stonkTable = db.StonkTable.Find(id);
            db.StonkTable.Remove(stonkTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

