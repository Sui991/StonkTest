using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using PersonalStockSystemTest.EFModel;

namespace PersonalStockSystemTest.Models

{
    public class DBmanager
    {
        // public override System.Windows.Media.ImageMetadata Metadata { get; }

        StonkDBEntities DB = new StonkDBEntities();      
 
        //public static string connectionString = "Data Source = localhost;Initial Catalog =StonkDB;User ID =sa;Password = a20774761a;";
        //SqlConnection ConnStr = new SqlConnection(connectionString);


        public List<StonkTable> GetStonks()
        {

     
           
            return DB.StonkTable.ToList();
        }
    }
}