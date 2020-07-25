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

        public void PatchCurrentPlayer(IEnumerable<GamePlay> data)
        {
            //var result = new Models.Room();
            //foreach (var item in data)
            //{
            //    result.RoomId = item.RoomId;
            //    result.Player1 = item.Player1;
            //    result.Player2 = item.Player2;
            //    result.Player3 = item.Player3;
            //    result.Player4 = item.Player4;
            //    result.Player5 = item.Player5;
            //    result.Player6 = item.Player6;
            //    result.Player7 = item.Player7;
            //    result.Player8 = item.Player8;
            //    result.Player9 = item.Player9;
            //    result.Player10 = item.Player10;
            //}
            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "update GameRoom set OccupationId = @OccupationId, isAlive=@IsAlive";
                conn.Execute(sql, data);
            }
        }
    }
}
