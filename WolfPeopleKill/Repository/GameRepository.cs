using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using Room = WolfPeopleKill.Models.Room;
using Dapper;

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
                             Id = o.OccupationId,
                             Name = o.OccupationName,
                             ImgUrl = o.Pic,
                             IsGood = Convert.ToBoolean(o.OccupationGb),
                             Description = o.About
                             
                          }).ToList();

            return result;
        }
        public List<Models.Room> GetPlayers(IEnumerable<Room> data)
        {
            
            var target = new DBModels.Room();

            foreach (var item in data)
            {
                target.RoomId = item.RoomId;
            }

            

            var result = (from r in _context.Room
                          where r.RoomId == target.RoomId
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

            return result;
        }

        public void PatchCurrentPlayer(Room data)
        {
            

        }
    }
}
