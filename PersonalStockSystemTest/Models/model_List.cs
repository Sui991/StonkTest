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
        
      

    }
}
