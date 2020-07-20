using System.Collections.Generic;
using System.Linq;
using Dapper;
using DbLibrary.Models;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.Interfaces;

namespace WolfPeopleKill.Repository
{
    public class DapperGameRepository : IGameRepo
    {
        //Dapper
        public List<Occupation> GetRoles()
        {
            var connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var result = conn.Query<Occupation>(sql).ToList();
                return result;
            }
        }
    }
}
