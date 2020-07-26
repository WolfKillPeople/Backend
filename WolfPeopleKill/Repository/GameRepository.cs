using System;
using System.Collections.Generic;
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

        public GameRepository(WerewolfkillContext context)
        {
            _context = context;
        }


        public List<Role> GetRoles()
        {
            var result = (from o in _context.Occupation
                          select new Role
                          {
                              Name = o.Occupation_Name,
                              ImgUrl = o.Pic,
                              Description = o.About,
                              IsGood = Convert.ToBoolean(o.Occupation_GB)
                          }).Take(10).ToList();

            return result;
        }

        public List<Models.Room> GetPlayers(List<GamePlay> data)
        {
            var result = (from o in _context.Room
                          where o.RoomId == data[0].RoomId
                          select new Models.Room
                          {
                              RoomId = o.RoomId,
                              Player1 = o.Player1,
                              Player2 = o.Player2,
                              Player3 = o.Player3,
                              Player4 = o.Player4,
                              Player5 = o.Player5,
                              Player6 = o.Player6,
                              Player7 = o.Player7,
                              Player8 = o.Player8,
                              Player9 = o.Player9,
                              Player10 = o.Player10
                          }).ToList();

            return result;
        }

        public void PatchCurrentPlayer(List<Models.Room> data)
        {

        }

        //推資料進GameRoom資料表
        public void PushGetRoles(IEnumerable<GamePlay> datas)
        {
            foreach (var item in datas)
            {
                var data = new GameRoom()
                {
                    RoomId = item.RoomId,
                    Players = item.Player,
                    OccupationId = _context.Occupation.FirstOrDefault(x => x.Occupation_Name == item.Name).OccupationId,
                    IsAlive = item.isAlive.ToString(),

                };

                var paramater = new GameRoom { RoomId = data.RoomId, Players = data.Players, OccupationId = data.OccupationId, IsAlive = data.IsAlive };
                _context.GameRoom.Update(paramater);

            }

            _context.SaveChanges();
        }

        public List<string> GetCurrentPlayer()
        {
            return null;

        }
    }
}
