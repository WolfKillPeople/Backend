using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    public class UserRepository :IUserRepo
    {


            public List<User> postpic(User data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<User> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.User { Email = data.Email,Pic = data.Pic};
                var sql = "update AspNetUsers set Pic = @Pic where Email = @Email " +
                    "select Pic,Email as email from AspNetUsers where Email = @Email";
                r=conn.Query<User>(sql, paramater).ToList();
            }
            return r;
        }

        public List<User> LoingPostpic(LoingPostpic data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<User> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.LoingPostpic { Email = data.Email};
                var sql =  "select Pic,Email as email from AspNetUsers where Email = @Email";
                r = conn.Query<User>(sql, paramater).ToList();
            }
            return r;
        }
    }
}
