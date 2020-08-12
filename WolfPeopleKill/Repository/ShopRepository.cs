using Dapper;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    public class ShopRepository : IShopRepo
    {
        private readonly string connStr =
               "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        
        public IEnumerable<Shop> GetShop()
        {
            IEnumerable<Shop> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select ProductId,ProductName,Price,Pic,Description from Shop";

                r=conn.Query<Shop>(sql);
            }
            return r;
        }
    }
}
