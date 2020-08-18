using System.Collections.Generic;
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

        public bool IsValid(LoginDTO request)
        {
            return _repo.IsVaild(request);
        }
    }
}
