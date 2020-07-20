using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.DBModels;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using WolfPeopleKill.Repository;

namespace WolfPeopleKill.DTO
{
    public class GameDTO : IGameDTO
    {
        private readonly IGameRepo _gameRepo;

        public GameDTO(IGameRepo gameRepo)
        {
            _gameRepo = gameRepo;
        }
        
        public List<Role> GetRole_Map()
        {

            var _list = _gameRepo.GetRoles();

            var result = (from l in _list
                select new Role()
                {
                    Name = l.Occupation_Name,
                    ImgUrl = l.Pic,
                    Description = l.About,
                    IsGood = Convert.ToBoolean(l.Occupation_GB)
                }).ToList();
            return result;
        }

    }
}
