using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalStockSystemTest.EFModel;
using System.Diagnostics;
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
        public string GetID()
        {
            var CrawerID = DB.StonkTable.Where(x => x.id == this.stID).FirstOrDefault();

            return CrawerID.stonkID.ToString() ;
        }

      public JsonResult GetPythonJson(string stonkID)
        {
           
            string python_path = @"C:\Users\user\AppData\Local\Programs\Python\Python311\python.exe";
            string pythonfile_path = @"D:\Desktop\StonkSystemTest\PersonalStockSystemTest\Scripts\Crawler.py";
            ProcessStartInfo startInfo = new ProcessStartInfo(python_path, pythonfile_path);
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.RedirectStandardInput = true;
            startInfo.CreateNoWindow = true;
            startInfo.Arguments = stonkID;
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            JsonResult json = new JsonResult();
            json.Data = process.StandardOutput.ReadToEnd();
            process.BeginErrorReadLine();
            process.WaitForExit();
            return json;
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
