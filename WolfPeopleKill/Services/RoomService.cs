using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services
{
    public class RoomService
    {
        List<Room> room = new List<Room>();
        int id = 0;
        public string AddRoom()
        {
            id++;
            bool isIdExist = room.Exists(x => x.Id == id);
            if (isIdExist == false)
            {
                room.Add(new Room { Id = id });
                return Convert.ToString(id);
            }
            else
            {
                return "新增失敗";
            }
        }
        
        public void RemoveRoom(string data)
        {
            int _data = Convert.ToInt32(data);
            bool isIdExist = room.Exists(x => x.Id == _data);
           
            try
            {
                if (isIdExist == true)
                {
                    var itemToRemove = room.Single(r => r.Id == _data);
                    room.Remove(itemToRemove);
                    
                }
            }
            catch (Exception ex)
            {
                
                
            }
            

        }
    }
}
