using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using Room = WolfPeopleKill.Models.Room;

namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// Dapper
    /// </summary>
    public class DapperGameRepository : IGameRepo
    {
        private readonly string connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        private readonly WerewolfkillContext _context;

        public DapperGameRepository(WerewolfkillContext context)
        {
            _context = context;
        }
        public List<GamePlay> RoomGetPlayers(List<Models.GamePlay> data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                var sql = "select * from AspNetUsers where RoomId = @RoomId";
                var total = conn.Query<AspNetUsers>(sql, data[0]).ToList();
                var result = new List<GamePlay>();
                foreach (var item in total)
                {
                    result.Add(new GamePlay { RoomId = Convert.ToInt32(item.RoomId), Account = item.UserName, PlayerPic = item.Pic });
                }
                return result;
            }
        }
        public List<Role> GetRoles()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                const string sql = "select top 10 Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var col = conn.Query<Role>(sql).ToList();
                return col;
            }
        }

        public List<Models.Room> GetPlayers(List<GamePlay> data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select * from Room where RoomID = @RoomId";
                var result = conn.Query<Room>(sql, data[0]).ToList();
                return result;
            }
        }

        public void PatchCurrentPlayer(List<KillPeoPle> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new DBModels.GameRoom { RoomId = data[0].RoomId, Players = data[0].Player };
                var sql = "update GameRoom set isAlive = 'false' where Players = @Players and RoomId = @RoomId";
                conn.Query<DBModels.Room>(sql, paramater);
            }
        }
        public List<KillPeoPle> GetCurrentPlayer(List<KillPeoPle> data)
        {
            List<KillPeoPle> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //var paramater = new Room { RoomId = data.RoomId, Player1 = data.Player1, Player2 = data.Player2, Player3 = data.Player3, Player4 = data.Player4, Player5 = data.Player5, Player6 = data.Player6, Player7 = data.Player7, Player8 = data.Player8, Player9 = data.Player9, Player10 = data.Player10 };
                var sql = "select Players from GameRoom where isAlive = 'True'";
                r = conn.Query<KillPeoPle>(sql).ToList();
            }
            return r.ToList();
        }



        //推資料進GameRoom資料表
        public void PushGetRoles(IEnumerable<Models.GamePlay> datas)
        {
            foreach (var item in datas)
            {
                var data = new GameRoom()
                {
                    RoomId = item.RoomId,
                    Players = item.Account,
                    OccupationId = _context.Occupation.FirstOrDefault(x => x.OccupationName == item.Name).OccupationId,
                    IsAlive = item.isAlive.ToString(),
                };
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    var paramater = new GameRoom { RoomId = data.RoomId, Players = data.Players, OccupationId = data.OccupationId, IsAlive = data.IsAlive };
                    //var sql = "update Room set RoomID = @RoomId,player1 = @Player1,player2 = @Player2,player3 = @Player3,player4 = @Player4,player5 = @Player5,player6 = @Player6,player7 = @Player7,player8 = @Player8,player9 = @Player9,player10 = @Player10";
                    var sql = "  insert into [dbo].[GameRoom](RoomId,Players,OccupationId,isAlive)values(@RoomId, @Players, @OccupationId, @IsAlive)";
                    conn.Query<GameRoom>(sql, paramater);
                }
            }

        }

        public void Savepeople(List<KillPeoPle> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new DBModels.GameRoom { RoomId = data[0].RoomId, Players = data[0].Player };
                var sql = "update GameRoom set isAlive = 'true' where Players = @Players and RoomId = @RoomId";
                conn.Query<DBModels.Room>(sql, paramater);
            }
        }

        public List<Models.Occupation> Observer(KillPeoPle data)
        {
            var result = new DBModels.GameRoom();
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<Models.Occupation> r = null;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new DBModels.GameRoom { RoomId = data.RoomId, Players = data.Player };
                var sql = "select * from GameRoom where RoomId = 1 and Players = 'Text002@gmail.com'";
                conn.Query<Models.Occupation>(sql, paramater);
                //r = conn.Query<KillPeoPle>(sql, paramater).FirstOrDefault();

            }
            return r;
        }

        public List<OutToRoom> OutToRoom(OutToRoom data)
        {
            throw new NotImplementedException();
        }

        public List<GameWin> GameWin(GameWin data)
        {
            throw new NotImplementedException();
        }
    }
}
