using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbLibrary.Models;
using WolfPeopleKill.DBModels;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameRepo
    {

        public List<Occupation> GetRoles();
    }
}
