using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    public class BuyRepository:IBuyRepo
    {
        private readonly string connStr =
               "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";

        public IEnumerable<Buy> GetBuy()
        {
            IEnumerable<Buy> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select Id,ProductId from Buy";

                r = conn.Query<Buy>(sql);
            }
            return r;
        }
        public List<Buy> NewBuy(Buy data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<Buy> a = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.Buy { Id = data.Id, ProductId = data.ProductId };
                var sql = "Insert into Buy (Id,ProductId) values(@Id,@ProductId)";
                a = conn.Query<Buy>(sql, paramater).ToList();
            }
            return a;
        }
    }
}
