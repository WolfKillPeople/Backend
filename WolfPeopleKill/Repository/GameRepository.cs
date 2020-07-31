using AutoMapper;
using Dapper;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        //private readonly string _conte;

        public GameRepository(WerewolfkillContext context, IMapper mapper,IConfiguration configuration)
        {
            //_context = context;
            _mapper = mapper;
            _configuration = configuration;
            var _context = _configuration.GetConnectionString("WerewolfkillConnection");
        }
        public List<GamePlay> RoomGetPlayers(List<Models.GamePlay> data)
        {
            var result = new List<GamePlay>();
            var total = _context.AspNetUsers.Where(x => data[0].RoomId == x.RoomId).ToList();

            foreach (var item in total)
            {
                result.Add(new GamePlay { RoomId = Convert.ToInt32(item.RoomId), Player = item.UserName, PlayerPic = item.Pic });
            }

            return result;
        }
        public List<Role> GetRoles()
        {
            var _list = _context.Occupation.Take(10).ToList();
            var result = _mapper.Map<List<Occupation>, List<Role>>(_list);
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
                    Players = item.Player,
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
        public List<KillPeoPle> Observer(KillPeoPle data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            List<KillPeoPle> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new KillPeoPle { RoomId = data.RoomId, Player = data.Player };
                var sql = "select g.roomId,g.Players as Player,o.Occupation_Name,g.isAlive from GameRoom g " +
                    "inner join Occupation o on o.Occupation_ID = g.OccupationId " +
                    "where RoomId = @RoomId and Players = @Player";
                r = conn.Query<KillPeoPle>(sql, paramater).ToList();
            }
            return r;
        }
    }
}
