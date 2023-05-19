using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalStockSystemTest.EFModel;
namespace PersonalStockSystemTest.Models
{
    public class model_List
    {

        private StonkDBEntities DB = new StonkDBEntities();
        public List<SelectListItem> select { get; set; }
        public int stID { get; set; }
        public int st_id { get; set; }
        public string st_name { get; set; }
        public Nullable<int> st_stonkID { get; set; }
        public string st_type { get; set; }
        public Nullable<System.DateTime> st_time { get; set; }
        public Nullable<int> st_num { get; set; }
        public Nullable<double> st_price { get; set; }
        public Nullable<double> st_tax { get; set; }
        public Nullable<double> st_fax { get; set; }
        public Nullable<System.DateTime> initDate { get; set; }
        public Nullable<int> total { get; set; }
        public List<StonkTable> Log_List { get; set; }
  
        public model_List()
        {
            this.Log_List = new List<StonkTable>();
            this.select = new List<SelectListItem>();
          
        }

        public string Init()
        {
            try
            {
                this.Log_List = DB.StonkTable.ToList();
                foreach (var item in Log_List)
                {
                    select.Add(new SelectListItem()
                    {
                        Text = item.name,
                        Value = item.id.ToString()
                    }
                    );
                }
            }
            catch (Exception e)
            {
                return e.ToString();
            }
            return "";
        }

        public void Create()
        {
            //try
            //{
                StonkTable addData = new StonkTable()
                {
                    id = this.st_id,
                    name = this.st_name,
                    stonkID=this.st_stonkID,
                    time=this.st_time,
                    type = this.st_type,
                    num = this.st_num,
                    price = this.st_price,
                    tax = this.st_tax,
                    fax = this.st_fax
                };
                DB.StonkTable.Add(addData);
                DB.SaveChanges();
            // }
            //catch (Exception e)
            //{
            //    return e.Message;
            //}
           
        }
        public string Search()
    {
            try
            {
                
                this.Log_List = DB.StonkTable.Where(x => x.id == this.stID).ToList();
            }
            catch(Exception e)
            {
                return e.ToString();

            }
            return "查詢成功";
    }
        public string Edit(int id)
        {
            try
            {  
               // this.Log_List = DB.StonkTable.Where(x => x.id == id).ToList();
                var editData = DB.StonkTable.Where(x => x.id == id).FirstOrDefault();
                //foreach (var item in this.Log_List)
                //{ 
                //editData.stonkID = item.stonkID; 
                //editData.name = item.name;
                //editData.time = item.time;
                //editData.type = item.type;
                //editData.num = item.num;
                //editData.price = item.price;
                //editData.tax = item.tax;
                //editData.fax = item.fax;

                //}
                editData.stonkID = this.st_stonkID;
                editData.name = this.st_name;
                editData.time = this.st_time;
                editData.type = this.st_type;
                editData.num = this.st_num;
                editData.price = this.st_price;
                editData.tax = this.st_tax;
                editData.fax = this.st_fax;

                DB.SaveChanges();
            }
            catch(Exception e)
            {
                return e.ToString();
            }
            return "";
        }
        public string Delete(int? id)
        {
            try
            {
                var removeData = DB.StonkTable.Where(x => x.id == id).FirstOrDefault();
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
