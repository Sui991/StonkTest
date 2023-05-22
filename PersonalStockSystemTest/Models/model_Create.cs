using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalStockSystemTest.EFModel;

namespace PersonalStockSystemTest.Models
{
    public class model_Create
    {
        private StonkDBEntities DB = new StonkDBEntities();
        public StonkTable CreateTable { set; get; }
        public model_Create() {
          
        }

    
    public string Create()
    {
        try
        {
                StonkTable newData = new StonkTable()
                {
                    id = CreateTable.id,
                    name = CreateTable.name,
                    stonkID = CreateTable.stonkID,
                    time = CreateTable.time,
                    type = CreateTable.type,
                    num = CreateTable.num,
                    price = CreateTable.price,
                    tax = CreateTable.tax,
                    fax = CreateTable.fax
                };
                DB.StonkTable.Add(newData);
                DB.SaveChanges();
            
        }

        catch(Exception e)
        {

            return e.ToString();
        }
        return "創建成功";
    }
    }
}