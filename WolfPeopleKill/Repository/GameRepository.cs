using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
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


        public List<Occupation> GetRoles()
        {
            var result = (from o in _context.Occupation
                          select new Occupation
                          {
                              Occupation_Name = o.Occupation_Name,
                              Pic = o.Pic,
                              About = o.About,
                              Occupation_GB = o.Occupation_GB
                          }).ToList();

            return result;
        }

        public List<DBModels.Room> GetPlayers(DBModels.Room data)
        {
            var result = (from o in _context.Room
                          where o.RoomId == data.RoomId
                          select o).ToList();

            return result;
        }

        public void PatchCurrentPlayer(DBModels.Room data)
        {
            _context.Room.Update(data);
            _context.SaveChanges();
        }

        public void PushGetRoles(IEnumerable<GamePlay> data)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<string> GetCurrentPlayer()
        {
            throw new System.NotImplementedException();
        }
    }
}
