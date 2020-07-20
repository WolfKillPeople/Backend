using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WolfPeopleKill.Models;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Xml;
using WolfPeopleKill.DTO;
using WolfPeopleKill.Interfaces;

namespace WolfPeopleKill.Services
{
    public class GameService :IGameService
    {
        private readonly IGameDTO _gameDto;

        public GameService(IGameDTO gameDto)
        {
            _gameDto = gameDto;
        }
        public List<Role> GetRole()
        {
            
            var _list = _gameDto.GetRole_Map();

            var random = new Random();
            dynamic temp;
            for (var i = 0; i < _list.Count; i++)
            {
                var index = random.Next(0, _list.Count - 1);
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
            var users = new StringBuilder();
            var i = json.UserId.Length;
            for (var o = 0; o < i; o++)
            {
                users.AppendLine(json.UserId[o]);
            }
            return users.ToString().Trim();
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
