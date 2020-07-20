using System;
using System.Collections.Generic;
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
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;
        public GameController(IGameService service)
        {
            _service = service;
        }

        /// <summary>
        /// 隨機分配角色
        /// </summary>
        /// <returns>IEnumerable json</returns>
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            var newline = _service.GetRole();
            return newline;
        }

        /// <summary>
        /// 遊戲開始時紀錄玩家
        /// </summary>
        /// <param name="data">data:{RoomId,UserId[]}</param>
        /// <returns>status code</returns>
        [HttpPost]
        public IActionResult StartAndRecord([FromBody]string data)
        {
            var json = JsonConvert.DeserializeObject<RecordUser>(data);
            var users = _service.Record(json);
            HttpContext.Session.SetString(json.RoomId, users);
            return Ok();
        }

        /// <summary>
        /// 現在存活的角色
        /// </summary>
        /// <param name="data">data:{RoomId,UserId[]}</param>
        /// <returns>status code</returns>
        [HttpPatch]
        public IActionResult PatchCurrentPlayer([FromBody]string data)
        {
            var json = JsonConvert.DeserializeObject<RecordUser>(data);
            HttpContext.Session.Remove(json.RoomId);
            var users = _service.Record(json);
            HttpContext.Session.SetString(json.RoomId, users);
            return Ok();
        }

        /// <summary>
        /// 輸贏判定
        /// </summary>
        /// <param name="data">isGood</param>
        /// <returns>true or false (win or lose)</returns>
        [HttpPost]
        public bool WinOrLose([FromBody]IEnumerable<Role> data)
        {
            var result = _service.WinOrLose(data);
            return result;
        }

    }
}
