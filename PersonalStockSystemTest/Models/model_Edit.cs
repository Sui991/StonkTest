using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalStockSystemTest.EFModel;
namespace PersonalStockSystemTest.Models
{
    public class model_Edit
    {
        private StonkDBEntities DB = new StonkDBEntities();
        public StonkTable UpdateData { get; set; }
   
    public model_Edit() {
          
        }
        public void Load(int id)
        {
            this.UpdateData = DB.StonkTable.Where(x => x.id == id).FirstOrDefault();
         
        }
        public string edit()
        {
            try
            {
              
                var old = DB.StonkTable.Where(x => x.id == UpdateData.id).FirstOrDefault();
                old.stonkID = UpdateData.stonkID;
                old.name = UpdateData.name;
                old.time = UpdateData.time;
                old.type = UpdateData.type;
                old.num = UpdateData.num;
                old.price = UpdateData.price;
                old.tax = UpdateData.tax;
                old.fax = UpdateData.fax;
                DB.SaveChanges();
            }
            catch(Exception e)
            {
                return e.ToString();
            }
            return "編輯成功";
        }
        public string Delete()
        {
            try
            {
                var removeData = DB.StonkTable.Where(x => x.id == UpdateData.id).FirstOrDefault();
                DB.StonkTable.Remove(removeData);
                DB.SaveChanges();

            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "";
        }
    }
}