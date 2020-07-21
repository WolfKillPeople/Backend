using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }

        /// <summary>
        /// 取得現在所有的房間列表
        /// </summary>
        /// <returns>JSON 沒有的話傳空字串</returns>

        [HttpGet]
        public IEnumerable<Room> CurrentRoom()
        {
            var result = _service.GetCurrentRoom();
            return result;
        }

        /// <summary>
        /// 第一次創建房間,增加房間並且增加玩家
        /// </summary>
        /// <param name="data">要被增加的id(房間號,玩家)  data:{RoomId,user}</param>
        /// <returns>id(房間號)</returns>

        [HttpPost]
        public IEnumerable<Room> AddRoom([FromBody] IEnumerable<Room> data)
        {
            var result = _service.AddRoom(data);

            return result;
        }

        /// <summary>
        /// 增加玩家
        /// </summary>
        /// <param name="data">data:{RoomId,userId} user是房間全部的</param>
        /// <returns>status code</returns>

        [HttpPatch]
        public IActionResult UpdatePlayer([FromBody] IEnumerable<Room> data)
        {
            _service.UpdatePlayer(data);
            return Ok();
        }



        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data">要被刪除的id(房間號) data:{RoomId,userId}</param>
        /////// <returns>status code</returns>
        [HttpDelete]
        public IActionResult RemoveRoom([FromBody] IEnumerable<Room> data)
        {
            _service.DeleteRoom(data);
            return Ok();
        }


    }
}
