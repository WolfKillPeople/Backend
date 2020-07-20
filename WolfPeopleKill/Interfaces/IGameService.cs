using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IGameService
    {
        public List<Role> GetRole();
        public string Record(RecordUser json);
        public bool WinOrLose(IEnumerable<Role> data);
    }
}
