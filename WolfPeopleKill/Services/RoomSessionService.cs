using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    
    public class RoomSessionService : IRoomService
    {
        public string AddRoom(IEnumerable<Room> data)
        {
            var sb = new StringBuilder();

            foreach (var item in data)
            {
                var userId = Convert.ToString(item.userId);
                sb.AppendLine(userId);
            }
            var str = Convert.ToString(sb);
            
            return str.Trim();
        }

        public string UpdatePlayer(string team,string userid)
        {
            var sb = new StringBuilder();

            var startIndexOf = team.IndexOf(userid);
            var newTeam = team.Remove(startIndexOf, userid.Length);
            return newTeam;
        }

        public IEnumerable<Room> GetCurrentRoom()
        {
            throw new NotImplementedException();
        }
    }
}
