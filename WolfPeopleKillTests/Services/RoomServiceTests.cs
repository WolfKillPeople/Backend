using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfPeopleKill.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WolfPeopleKill.Models;
using System.Linq;

namespace WolfPeopleKill.Services.Tests
{
    [TestClass()]
    public class RoomServiceTests
    {

        [TestMethod()]
        public void AddRoomTest()
        {
            List<Room> room = new List<Room>();
            
            int id = 0;

            id++;
            bool isIdExist = room.Exists(x => x.Id == id);
            if (isIdExist == false)
            {
                room.Add(new Room { Id = id });
                Assert.IsNotNull(room);
            }

        }

        [TestMethod()]
        public void RemoveRoomTest()
        {
            List<Room> room = new List<Room>()
            {
                new Room{Id = 1}
            };
            
            string data = "1";
            int _data = Convert.ToInt32(data);
            bool isIdExist = room.Exists(x => x.Id == _data);
            
            if (isIdExist == true)
            {
                var itemToRemove = room.Single(r => r.Id == _data);
                room.Remove(itemToRemove);
                Assert.AreEqual(0,room.Count);
            }

        }
    }
}