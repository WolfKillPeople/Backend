using Microsoft.VisualStudio.TestTools.UnitTesting;
using WolfPeopleKill.Services;
using System;
using System.Collections.Generic;
using System.Text;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Services.Tests
{
    [TestClass()]
    public class RoomServiceTests
    {
        [TestMethod()]
        public void AddRoomTest()
        {
            StringBuilder sb = new StringBuilder();
            List<Room> data = new List<Room>()
            {
                new Room{Id = 1, People = 1},
            };

            foreach (var item in data)
            {
                var people = Convert.ToString(item.People);
                sb.AppendLine(people);
                
            }
            var str = Convert.ToString(sb);
            string ex = "1";
            Assert.AreEqual(ex,str.Trim());
        }
    }
}