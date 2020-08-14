using AutoMapper;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;


namespace WolfPeopleKill.Repository
{
    /// <summary>
    /// EntityFramework
    /// </summary>
    public class GameRepository : IGameRepo
    {
        private readonly WerewolfkillContext _context;
        private readonly IMapper _mapper;
        
        public GameRepository(WerewolfkillContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public List<GamePlay> RoomGetPlayers(List<Models.GamePlay> data)
        {
            var result = new List<GamePlay>();
            var total = _context.AspNetUsers.Where(x => data[0].RoomId == x.RoomId).ToList();

            total.ForEach(o=>result.Add(new GamePlay(){ RoomId = Convert.ToInt32(o.RoomId), Account = o.UserName, PlayerPic = o.Pic }));
            return result;
        }
        public List<Role> GetRoles()
        {
            var _list = _context.Occupation.Take(10).ToList();
            var result = _mapper.Map<List<DBModels.Occupation>, List<Role>>(_list);
            return result;
        }

        public List<Models.Room> GetPlayers(List<GamePlay> data)
        {
            var _list = _context.Room.Where(x => data[0].RoomId == x.RoomId).ToList();
            var result = _mapper.Map<List<DBModels.Room>, List<Models.Room>>(_list);
            return result;
        }

        public void PatchCurrentPlayer(List<KillPeoPle> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new DBModels.GameRoom { RoomId = data[0].RoomId,Players = data[0].Player};
                var sql = "update GameRoom set isAlive = 'false' where Players = @Players and RoomId = @RoomId";
                conn.Query<DBModels.Room>(sql, paramater);
            }
        }

        public void Savepeople(List<KillPeoPle> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new DBModels.GameRoom { RoomId = data[0].RoomId, Players = data[0].Player};
                var sql = "update GameRoom set isAlive = 'True' where Players = @Players and RoomId = @RoomId";
                conn.Query<DBModels.Room>(sql, paramater);
            }
        }


        public void PushGetRoles(IEnumerable<GamePlay> datas)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
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
                    var sql = "  insert into [dbo].[GameRoom](RoomId,Players,OccupationId,isAlive)values(@RoomId, @Players, @OccupationId, @IsAlive)";
                    conn.Query<GameRoom>(sql, paramater);
                }
            }
        }

        public List<KillPeoPle> GetCurrentPlayer(List<KillPeoPle> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<KillPeoPle> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new GameRoom { RoomId = data[0].RoomId};
                var sql = "select g.RoomId,g.Players as Player,o.Occupation_Name,g.isAlive from GameRoom g " +
                    "inner join Occupation o on o.Occupation_Id = g.OccupationId where RoomId = @RoomId";
                r = conn.Query<KillPeoPle>(sql,data[0]).ToList();
            }
            return r;
        }
        public List<Models.Occupation> Observer(KillPeoPle data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<Models.Occupation> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new KillPeoPle { RoomId = data.RoomId, Player = data.Player };
                var sql = "select o.Occupation_GB from GameRoom g " +
                    "inner join Occupation o on o.Occupation_ID = g.OccupationId " +
                    "where RoomId = @RoomId and Players = @Player";
                r = conn.Query<Models.Occupation>(sql, paramater).ToList();
            }
            return r;
        }
        public List<OutToRoom> OutToRoom(OutToRoom data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<OutToRoom> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.OutToRoom { RoomId = data.RoomId,Player = data.Player };
                var sql = " DELETE FROM GameRoom WHERE RoomID = @RoomId and Players = @Player " +
                    "Select RoomId,Players as Player from GameRoom where RoomId = @RoomId";
                r= conn.Query<OutToRoom>(sql, paramater).ToList();
            }
            return r;
        }
        public List<GameWin> GameWin(GameWin data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<GameWin> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.GameWin { Name = data.Name};
                var sql = " UPDATE  AspNetUsers SET Win = ISNULL(Win,0)+1 where UserName = @Name " +
                    "select UserName as Name,Win from AspNetUsers where UserName = @Name ";
                r = conn.Query<GameWin>(sql, paramater).ToList();
            }
            return r;
        }
    }
}
