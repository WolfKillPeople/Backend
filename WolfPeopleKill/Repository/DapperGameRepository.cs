using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;

namespace WolfPeopleKill.Repository
{
    //Dapper
    public class DapperGameRepository : IGameRepo
    {
        private readonly string connStr =
                "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
        private readonly WerewolfkillContext context;

        public DapperGameRepository(WerewolfkillContext context)
        {
            this.context = context;
        }
        public List<Occupation> GetRoles()
        {

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select Occupation_Name, Occupation_GB, Pic, About from Occupation";
                var result = conn.Query<Occupation>(sql).ToList();
                return result;
            }
        }

        public List<Room> GetPlayers(Room data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //var sql = "select * Room where @data.RoomId = RoomID";
                var sql = "select * from Room where  RoomID = @data";
                var result = conn.Query<Room>(sql ,new { data = data .RoomId}).ToList();
                return result;
            }
        }

        public void PatchCurrentPlayer(Room data)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Room { RoomId = data.RoomId, Player1 = data.Player1, Player2 = data.Player2, Player3 = data.Player3, Player4 = data.Player4, Player5 = data.Player5, Player6 = data.Player6, Player7 = data.Player7, Player8 = data.Player8, Player9 = data.Player9, Player10 = data.Player10 };
                //var paramater = new Room { RoomId = data.RoomId, player = data.Pl};
                var sql = "update GameRoom set isAlive = 'false' where Players = 'string' and RoomId = 1";
                //var sql = "select Players from GameRoom where isAlive = 'True' and RoomId = 1";
                conn.Query<Room>(sql, paramater);
            }
        }
        public IEnumerable<string> GetCurrentPlayer()
        {
            IEnumerable<string> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                //var paramater = new Room { RoomId = data.RoomId, Player1 = data.Player1, Player2 = data.Player2, Player3 = data.Player3, Player4 = data.Player4, Player5 = data.Player5, Player6 = data.Player6, Player7 = data.Player7, Player8 = data.Player8, Player9 = data.Player9, Player10 = data.Player10 };
                var sql = "select Players from GameRoom where isAlive = 'True'";
                r= conn.Query<string>(sql);
            }
            return r;
        }



        //推資料進GameRoom資料表
        public void PushGetRoles(IEnumerable<Models.GamePlay> datas)
        {
            foreach (var item in datas)
            {
                var data = new GameRoom()
                {
                    RoomId = item.RoomId,
                    Players = item.Player,
                    OccupationId = context.Occupation.FirstOrDefault(x => x.Occupation_Name == item.Name).OccupationId,
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
    }
}
