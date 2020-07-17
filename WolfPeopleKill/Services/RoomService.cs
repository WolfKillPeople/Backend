using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class RoomService
    {
        public string AddRoom(IEnumerable<Room> data)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var item in data)
            {
                var id = Convert.ToString(item.Id);
                var userID = Convert.ToString(item.userId);
            
                sb.AppendLine(userID);
            }
            var str = Convert.ToString(sb);
            
            return str.Trim();
        }
    }
}
