using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using WolfPeopleKill.Services;

namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly RoomSessionService _service;

        public RoomController(RoomSessionService service)
        {
            _service = service;
        }

        /// <summary>
        /// 取得現在的房間列表
        /// </summary>
        /// <returns>string 沒有的話傳空字串</returns>
        [HttpGet]
        public string CurrentRoom()
        {
            if (HttpContext.Session.GetString("AllRoom") != null)
            {
                var allRoom = HttpContext.Session.GetString("AllRoom");
                return allRoom;
            }

            return "";
        }

        /// <summary>
        /// 增加房間並且增加玩家
        /// </summary>
        /// <param name="data">要被增加的id(房間號,玩家)  data:{RoomId,userId}</param>
        /// <returns>id(房間號)</returns>
        
        [HttpPost]
        public IActionResult AddRoom([FromBody]IEnumerable<Room> data)
        {
            var newData = _service.AddRoom(data);
            foreach (var item in data)
            {
                HttpContext.Session.SetString(Convert.ToString(item.RoomId), newData);
                HttpContext.Session.SetString("AllRoom",Convert.ToString(item.RoomId));
            }

            return Ok();
        }

        /// <summary>
        /// delete player
        /// </summary>
        /// <param name="data">離開的玩家的RoomId跟userId data:{RoomId,userId}</param>
        /// <returns>status code</returns>
        [HttpDelete]
        public IActionResult RemovePlayer([FromBody] IEnumerable<Room> data)
        {
            foreach (var item in data)
            {
                var temp = HttpContext.Session.GetString(Convert.ToString(item.RoomId));
                var newTeam = _service.UpdatePlayer(temp, Convert.ToString(item.userId));
                HttpContext.Session.Remove(Convert.ToString(item.RoomId));
                HttpContext.Session.SetString(Convert.ToString(item.RoomId), newTeam) ;
            }
            return Ok();
        }

        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data">要被刪除的id(房間號) data:{RoomId,userId}</param>
        /////// <returns>status code</returns>
        [HttpDelete]
        public IActionResult RemoveRoom([FromBody]string data)
        {
            HttpContext.Session.Remove(data);
            return Ok();
        }

       
    }
}
