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
        // SqlConnection ConnStr = new SqlConnection(ConfigurationManager.ConnectionStrings["MSSQL_DBconnect"].ConnectionString);
        StonkDBEntities DB = new StonkDBEntities();

        public List<StonkTable> GetStonks()
        {

            //SqlDataReader reader;
            //List<Stonk> stonks = new List<Stonk>();

            //SqlCommand sqlCommand = new SqlCommand("SELECT * FROM StonkTable", ConnStr);


            //ConnStr.Open();
            //reader = sqlCommand.ExecuteReader();
            //if (reader.HasRows)
            //{
            //    while (reader.Read())
            //    {
            //        Stonk stonk = new Stonk
            //        {
            //            ID = reader.GetInt32(reader.GetOrdinal("id")),//將資料庫中Name欄位存放於NameStr字串中
            //            name = reader.GetString(reader.GetOrdinal("name"))      //將資料庫中ID欄位存放於IDint整數中，不同型態請自行更改
            //                                                                               這邊建議欄位與字串相同，方便管理，怕人搞混所以這邊用不同名稱
            //        };

            //        stonks.Add(stonk);
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("資料庫為空！");
            //}
            //ConnStr.Close();
            return DB.StonkTable.ToList();
        }
    }
}