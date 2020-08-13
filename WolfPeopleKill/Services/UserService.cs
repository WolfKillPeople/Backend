using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _repo;
        public UserService(IUserRepo repo)
        {
            _repo = repo;
        }
        public List<User> PatchUserPic(User data)
        {
            return _repo.postpic(data);
        }

        public List<User> LoingPostpic(LoingPostpic data)
        {
            return _repo.LoingPostpic(data);
        }
        public List<UserWin> PostWin(UserWin data)
        {
            return _repo.PostWin(data);
        }
        public List<UserWin> GetWin(UserWin data)
        {
            return _repo.GetWin(data);
        }
    }
}
