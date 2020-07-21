using System;
using System.Collections.Generic;
using WolfPeopleKill.Models;
using WolfPeopleKill.Interfaces;
using System.Collections;

namespace WolfPeopleKill.Services
{
    public class GameService : IGameService
    {
        private readonly IGameDTO _gameDto;

        public GameService(IGameDTO gameDto)
        {
            _gameDto = gameDto;
        }

        public List<GamePlay> GetRole(IEnumerable<GamePlay> data)
        {

            var _list = _gameDto.GetRole_Map();

            var players = _gameDto.GetPlayers_Map(data);

            string player1 = "";
            string player2 = "";
            string player3 = "";
            string player4 = "";
            string player5 = "";
            string player6 = "";
            string player7 = "";
            string player8 = "";
            string player9 = "";
            string player10 = "";
            int roomId = 0;

            ArrayList ary = new ArrayList();

            foreach (var item in players)
            {
                roomId = item.RoomId;
                player1 = item.Player1;
                player2 = item.Player2;
                player3 = item.Player3;
                player4 = item.Player4;
                player5 = item.Player5;
                player6 = item.Player6;
                player7 = item.Player7;
                player8 = item.Player8;
                player9 = item.Player9;
                player10 = item.Player10;
            }

            ary.Add(player1);
            ary.Add(player2);
            ary.Add(player3);
            ary.Add(player4);
            ary.Add(player5);
            ary.Add(player6);
            ary.Add(player7);
            ary.Add(player8);
            ary.Add(player9);
            ary.Add(player10);

            var newary = ary.ToArray();
            var newList = new List<GamePlay>();

            for (int i = 0; i < newary.Length; i++)
            {
                newList.Add(new GamePlay { RoomId = roomId, Player = Convert.ToString(newary[i]), Name = _list[i].Name, ImgUrl = _list[i].ImgUrl, Description = _list[i].Description, IsGood = _list[i].IsGood,isAlive=true });
            }

            var random = new Random();
            dynamic temp;
            for (var i = 0; i < newList.Count; i++)
            {
                var index = random.Next(0, newList.Count - 1);
                if (index != i)
                {
                    temp = newList[i];
                    newList[i] = newList[index];
                    newList[index] = temp;
                }
            };
            

            return newList;
        }

        public void PatchCurrentPlayer(IEnumerable<Room> data)
        {
            _gameDto.PatchCurrentPlayer(data);
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
