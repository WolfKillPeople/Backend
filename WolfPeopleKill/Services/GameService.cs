using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Xml;

namespace WolfPeopleKill.Services
{
    public class GameService
    {
        public List<Role> GetRole()
        {
            Random random = new Random();

            List<Role> _list = new List<Role>()
            {
                new Role{Id = 1, Name="狼王",ImgUrl="//i.imgur.com/fVQQgnM.png",Description="狼王",IsGood=true},
                new Role{Id = 2,Name = "狼人",ImgUrl="//i.imgur.com/n7knadr.png",Description="狼人",IsGood=false},
                new Role{Id = 3,Name="狼人",ImgUrl="//i.imgur.com/n7knadr.png",Description="狼人",IsGood=true},
                new Role{Id = 4,Name="預言家",ImgUrl="//i.imgur.com/8tiIFAB.png",Description="預言家",IsGood=true},
                new Role{Id = 5,Name="女巫",ImgUrl="//i.imgur.com/i9eRyug.png",Description="女巫",IsGood=true},
                new Role{Id = 6,Name="獵人",ImgUrl="//i.imgur.com/TIvcUG5.png",Description="獵人",IsGood=true},
                new Role{Id = 7,Name="村民",ImgUrl="//i.imgur.com/4eJqZgk.png",Description="村民男",IsGood=true},
                new Role{Id = 8,Name="村民",ImgUrl="//i.imgur.com/D2o6MV6.png",Description="村民女",IsGood=true},
                new Role{Id = 9,Name="村民",ImgUrl="//i.imgur.com/4eJqZgk.png",Description="村民男",IsGood=true},
                new Role{Id = 10,Name="村民",ImgUrl="//i.imgur.com/D2o6MV6.png",Description="村民女",IsGood=true}
            };

            int index = 0;
            dynamic temp;
            for (int i = 0; i < _list.Count; i++)
            {
                index = random.Next(0, _list.Count - 1);
                if (index != i)
                {
                    temp = _list[i];
                    _list[i] = _list[index];
                    _list[index] = temp;
                }
            };
            return _list;
        }

        public string Record(RecordUser json)
        {
            StringBuilder users = new StringBuilder();
            int i = json.UserId.Length;
            for (int o = 0; o < i; o++)
            {
                users.AppendLine(json.UserId[o]);
            }
            return users.ToString();
        }

        public string CurrentPlayer(RecordUser json, string sess)
        {
            var result = new RecordUser
            {
                RoomId = json.RoomId,
                UserId = sess.Split(" ")
            };
            string strJson = JsonConvert.SerializeObject(result, Newtonsoft.Json.Formatting.Indented);
            return strJson;
        }

        public bool WinOrLose(IEnumerable<Role> data)
        {
            int tempBad = 0;

            foreach (var item in data)
            {
                switch (item.IsGood)
                {
                    case false:
                        tempBad++;
                        break;
                    default:
                        break;
                }
            }

            if (tempBad == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
