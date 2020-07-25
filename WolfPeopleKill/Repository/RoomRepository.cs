using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using Dapper;
using Room = WolfPeopleKill.DBModels.Room;
using System.Collections;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// EntityFramework
    /// </summary>
    public class RoomRepository : IRoomRepo
    {
        private readonly WerewolfkillContext _context;

        public RoomRepository(WerewolfkillContext context)
        {
            _context = context;
        }

        public List<Models.Room> GetRoom()
        {
            var _list = (from r in _context.Room
                select new Models.Room
                {
                    RoomId = r.RoomId,
                    Player1 = r.Player1,
                    Player2 = r.Player2,
                    Player3 = r.Player3,
                    Player4 = r.Player4,
                    Player5 = r.Player5,
                    Player6 = r.Player6,
                    Player7 = r.Player7,
                    Player8 = r.Player8,
                    Player9 = r.Player9,
                    Player10 = r.Player10
                }).ToList();
            return _list;

        }

        public List<Models.Room> AddRoom(IEnumerable<Models.Room> _list)
        {
            const string connStr =
                @"data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var target = new DBModels.Room();
                foreach (var item in _list)
                {
                    target.RoomId = item.RoomId;
                    target.Player1 = item.Player1;
                }

                var targetList = new GameRoom();
                foreach (var l in _list)
                {
                    targetList.RoomId = l.RoomId;
                    targetList.Players = l.Player1;
                }


                _context.Room.Add(target);
                _context.SaveChanges();

                string sql = "DECLARE @TotalNum INT, @Num INT, @Value CHAR(20) SET @TotalNum = 10 SET @Num = 1 WHILE @Num <= @TotalNum BEGIN insert into GameRoom(RoomId, Players) values(@RoomId, @Players)  SET @Num = @Num + 1 END";
                conn.Execute(sql, targetList);



                var result = (from r in _context.Room
                              where r.RoomId == target.RoomId
                              select new Models.Room
                              {
                                  RoomId = r.RoomId,
                                  Player1 = r.Player1,
                                  TotalPlayers = 1
                              }).ToList();

                return result;
            }
        }

        public List<Models.Room> UpdatePlayer(IEnumerable<Models.Room> _list)
        {
            const string connStr =
                @"data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var target = new DBModels.Room();
                foreach (var item in _list)
                {
                    target.RoomId = item.RoomId;
                    target.Player1 = item.Player1;
                    target.Player2 = item.Player2;
                    target.Player3 = item.Player3;
                    target.Player4 = item.Player4;
                    target.Player5 = item.Player5;
                    target.Player6 = item.Player6;
                    target.Player7 = item.Player7;
                    target.Player8 = item.Player8;
                    target.Player9 = item.Player9;
                    target.Player10 = item.Player10;
                }

                var targetList = new List<GameRoom>();
                foreach (var l in _list)
                {
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player1, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player2, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player3, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player4, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player5, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player6, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player7, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player8, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player9, OccupationId = null, IsAlive = "true" });
                    targetList.Add(new GameRoom() { RoomId = l.RoomId, Players = l.Player10, OccupationId = null, IsAlive = "true" });
                }


                var sql = @"Update Room Set Player1 = @Player1,Player2 = @Player2,Player3 = @Player3,Player4 = @Player4,Player5 = @Player5, Player6 = @Player6,Player7 = @Player7, Player8=@Player8,Player9 = @Player9,Player10 = @Player10 where RoomID = @RoomId";
                conn.Execute(sql, target);

                //var _sql = @"Update GameRoom Set Players = @Players,OccupationId = @OccupationId,isAlive=@IsAlive where RoomID = @RoomId";
                //var _sql = "DECLARE @TotalNum INT, @Num INT, @Value CHAR(20) SET @TotalNum = 10 SET @Num = 1 WHILE @Num <= @TotalNum BEGIN update GameRoom Set Players = @Players,OccupationId = @OccupationId,isAlive=@IsAlive where RoomID = @RoomId  SET @Num = @Num + 1 END";
                //conn.Execute(_sql, targetList);





                var getSql = "Select * from Room where RoomID = @RoomID";
                var result = conn.Query<Models.Room>(getSql, target).ToList();



               
                return result;
            }
           
        }
        

        public void DeleteRoom(IEnumerable<Models.Room> _list)
        {
            try
            {
                var result = new Room();
                var _result = new GameRoom();
                foreach (var item in _list)
                {
                    result.RoomId = item.RoomId;
                    result.Player1 = item.Player1;
                    result.Player2 = item.Player2;
                    result.Player3 = item.Player3;
                    result.Player4 = item.Player4;
                    result.Player5 = item.Player5;
                    result.Player6 = item.Player6;
                    result.Player7 = item.Player7;
                    result.Player8 = item.Player8;
                    result.Player9 = item.Player9;
                    result.Player10 = item.Player10;
                    _result.RoomId = item.RoomId;
                }

                var query = _context.Room.Where(x => x.RoomId == result.RoomId);
                _context.Room.RemoveRange(query);
                var _query = _context.GameRoom.Where(x => x.RoomId == _result.RoomId);
                _context.GameRoom.RemoveRange(_query);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
