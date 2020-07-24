using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperGameRepository : IGameRepo
    {
        private readonly string connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        
        public List<Occupation> GetRoles()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "select Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var result = conn.Query<Occupation>(sql).ToList();
                return result;
            }
        }

        public List<Room> GetPlayers(Room data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string _sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Room>(_sql, new Room() { RoomId = data.RoomId }).ToList();
                return result;
            }
        }

        public void PatchCurrentPlayer(Room data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "update Room set RoomID = @RoomId,player1 = @Player1,player2 = @Player2,player3 = @Player3,player4 = @Player4,player5 = @Player5,player6 = @Player6,player7 = @Player7,player8 = @Player8,player9 = @Player9,player10 = @Player10";
                conn.Execute(sql, data);
            }
        }
    }
}
