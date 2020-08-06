using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IUserRepo
    {
        public List<User> postpic(User data);
        public List<User> LoingPostpic(LoingPostpic data);

        
    }
}
