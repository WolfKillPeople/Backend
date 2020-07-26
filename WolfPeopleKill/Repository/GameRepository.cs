using AutoMapper;
using Dapper;
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

        public void PatchCurrentPlayer(List<Models.Room> data)
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var paramater = new Models.Room { RoomId = data[0].RoomId, Player1 = data[0].Player1, Player2 = data[0].Player2, Player3 = data[0].Player3, Player4 = data[0].Player4, Player5 = data[0].Player5, Player6 = data[0].Player6, Player7 = data[0].Player7, Player8 = data[0].Player8, Player9 = data[0].Player9, Player10 = data[0].Player10 };
                var sql = "update GameRoom set isAlive = 'false' where Players = 'string' and RoomId = 1";
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
                    OccupationId = _context.Occupation.FirstOrDefault(x => x.Occupation_Name == item.Name).OccupationId,
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

        public List<string> GetCurrentPlayer()
        {
            string connStr = "data source=werewolfkill.database.windows.net;initial catalog=Werewolfkill;persist security info=True;user id=Werewolfkill;password=Wolfpeoplekill_2020;MultipleActiveResultSets=True;";
            IEnumerable<string> r = null;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                var sql = "select Players from GameRoom where isAlive = 'True'";
                r = conn.Query<string>(sql);
            }
            return r.ToList();
        }
    }
}
