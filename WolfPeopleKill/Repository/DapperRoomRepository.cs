using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperRoomRepository : IRoomRepo
    {
        private readonly string connStr =
               "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        public List<DBModels.Room> AddRoom(Room target)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "Insert into Room (RoomID,player1,player2,player3,player4,player5,player6,player7,player8,player9,player10) values(@RoomID,@player1,@player2,@player3,@player4,@player5,@player6,@player7,@player8,@player9,@player10)";
                conn.Execute(sql,target);
                var _sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Room>(_sql, new Room() { RoomId = target.RoomId }).ToList();
                return result;
            }   
        }

        public void DeleteRoom(Room _list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "Delete from Room where RoomID = @RoomId";
                conn.Execute(sql,new Room(){RoomId = _list.RoomId});
            }
        }

        public IEnumerable<Room> GetRoom()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select * from Room";
                var result = conn.Query<Room>(sql).ToList();
                return result;
            }
        }

        public List<Room> UpdatePlayer(Room _list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "update Room set RoomID = @RoomId,player1 = @Player1,player2 = @Player2,player3 = @Player3,player4 = @Player4,player5 = @Player5,player6 = @Player6,player7 = @Player7,player8 = @Player8,player9 = @Player9,player10 = @Player10";
                conn.Execute(sql,_list);
                const string _sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Room>(_sql,new Room(){RoomId = _list.RoomId}).ToList();
                return result;
            }
        }
    }
}
