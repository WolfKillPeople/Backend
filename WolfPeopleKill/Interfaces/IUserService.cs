using System.Collections.Generic;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IUserService
    {
        public List<User> PatchUserPic(User data);
        public List<User> LoingPostpic(LoingPostpic data);
        public List<UserWin> PostWin(UserWin data);
        public List<UserWin> GetWin(UserWin data);
        public bool IsValid(LoginDTO request);
    }
}
