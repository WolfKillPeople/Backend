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
    public class DapperRoomRepository /*: IRoomRepo*/
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
                var _sql = "select @target.RoomID from Room";
                var result = conn.Query<Room>(_sql).ToList();
                return result;
            }   
        }

        public void DeleteRoom(Room _list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "Delete from Room where RoomID = @_list.RoomId";
                conn.Execute(sql);
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

        //public List<Room> UpdatePlayer(Room _list)
        //{
        //    //using (SqlConnection conn = new SqlConnection(connStr))
        //    //{
        //    //    conn.Open();
        //    //    var sql = "update Room set "
        //    //}
        //}
    }
}
