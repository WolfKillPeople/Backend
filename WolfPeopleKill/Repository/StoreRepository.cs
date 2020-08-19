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
    public class StoreRepository:IStoreRepo
    {
        private readonly string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";

        public List<Store> PostScore(Store data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.Store { Email = data.Email, win = data.win, pic = data.pic };
                var sql = @"update AspNetUsers set win = @win, pic = @pic where Email = @Email";
                var r = conn.Query<Store>(sql, paramater).ToList();
                conn.Close();
                return r;
            }
        }
    }
}
