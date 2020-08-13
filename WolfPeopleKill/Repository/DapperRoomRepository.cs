using System.Collections.Generic;
using System.Linq;
using WolfPeopleKill.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using AutoMapper;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperRoomRepository : IRoomRepo
    {
        private readonly IMapper _mapper;
        private readonly string connStr =
               "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        public DapperRoomRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public List<Models.Room> AddRoom(IEnumerable<Models.Room> _list)
        {
            var result = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(_list.ToList());

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "Insert into Room (RoomID,player1,player2,player3,player4,player5,player6,player7,player8,player9,player10) values(@RoomID,@player1,@player2,@player3,@player4,@player5,@player6,@player7,@player8,@player9,@player10)";
                conn.Execute(sql, result);
                var _sql = "select * from Room where RoomID = @RoomId";
                var collection = conn.Query<Models.Room>(_sql, result).ToList();
                return collection;
            }
        }

        public List<Models.Room> DeleteRoom(IEnumerable<Models.Room> _list)
        {
            var result = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(_list.ToList());

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "Delete from Room where RoomID = @RoomId";
                conn.Execute(sql, result);

                var _sql = "select * from Room";
                var query = conn.Query(_sql).ToList();
                var _result = (from r in query
                              select new Models.Room
                              {
                                  TempRoomID = _list.ToList()[0].RoomId.ToString()
                              }).ToList();
                return _result;
            }
        }

        public List<Models.Room> GetRoom()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select * from Room";
                var result = conn.Query<Models.Room>(sql).ToList();
                return result;
            }
        }

        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list)
        {
            var result = _mapper.Map<List<Models.Room>, List<DBModels.Room>>(_list.ToList());
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "update Room set RoomID = @RoomId,player1 = @Player1,player2 = @Player2,player3 = @Player3,player4 = @Player4,player5 = @Player5,player6 = @Player6,player7 = @Player7,player8 = @Player8,player9 = @Player9,player10 = @Player10";
                conn.Execute(sql, _list);
                const string _sql = "select * from Room where RoomID = @RoomId";
                var collection = conn.Query<Models.Room>(_sql, result).ToList();
                return collection;
            }
        }
    }
}
