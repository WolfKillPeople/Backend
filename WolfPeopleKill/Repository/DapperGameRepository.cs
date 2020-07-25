using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperGameRepository : IGameRepo
    {
        private readonly string connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";

        public List<Role> GetRoles()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "select Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var result = conn.Query<Role>(sql).ToList();
                return result;
            }
        }

        public List<Models.Room> GetPlayers(IEnumerable<Models.Room> data)
        {
            var target = new GamePlay();
            foreach (var item in data)
            {
                target.RoomId = item.RoomId;
            }
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string _sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Models.Room>(_sql, target).ToList();
                return result;
            }
        }

        public void PatchCurrentPlayer(Room data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Room { RoomId = data.RoomId, Player1 = data.Player1, Player2 = data.Player2, Player3 = data.Player3, Player4 = data.Player4, Player5 = data.Player5, Player6 = data.Player6, Player7 = data.Player7, Player8 = data.Player8, Player9 = data.Player9, Player10 = data.Player10 };
                var sql = "update GameRoom set isAlive = 'false' where Players = 'string' and RoomId = @RoomId";
                conn.Query<Room>(sql, paramater);
            }
        }
    }
}
