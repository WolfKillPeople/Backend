using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Data.SqlClient;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;

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
                              OccupationName = o.OccupationName,
                              Pic = o.Pic,
                              About = o.About,
                              OccupationGb = o.OccupationGb
                          }).ToList();

            return result;
        }

        public List<Room> GetPlayers(Room data)
        {
            var result = (from o in _context.Room
                          where o.RoomId == data.RoomId
                          select o).ToList();

            return result;
        }

        public void PatchCurrentPlayer(Room data)
        {

            _context.Room.Update(data);
            _context.SaveChanges();
        }
    }
}
