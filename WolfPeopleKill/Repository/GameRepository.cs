using System.Collections.Generic;
using System.Linq;
using Dapper;
using DbLibrary.Models;
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
                    Occupation_Name = o.Occupation_Name,
                    Pic = o.Pic,
                    About = o.About,
                    Occupation_GB = o.Occupation_GB
                }).ToList();

            return result;
        }
    }
}
