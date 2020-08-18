using WolfPeopleKill.Models;

namespace WolfPeopleKill.Interfaces
{
    public interface IAuthenticateService
    {
        bool IAuthenticated(LoginDTO request, out string token);
    }
}
