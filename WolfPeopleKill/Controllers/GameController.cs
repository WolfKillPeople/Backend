using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WolfPeopleKill.Models;
using WolfPeopleKill.Services;


namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        GameService _service = new GameService();
        private readonly ILogger<GameController> _logger;
        public GameController(ILogger<GameController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// 隨機分配角色
        /// </summary>
        /// <returns>IEnumerable json</returns>
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            var _newlist = _service.GetRole();
            return _newlist;
        }

        /// <summary>
        /// 遊戲開始時紀錄玩家
        /// </summary>
        /// <param name="data">data:{RoomId,UserId}</param>
        /// <returns>status code</returns>
        [HttpPost]
        public IActionResult StartAndRecord([FromBody]string data)
        {
            var json = JsonConvert.DeserializeObject<RecordUser>(data);
            var users = _service.Record(json);
            HttpContext.Session.SetString(json.RoomId, users.ToString());
            return Ok();
        }

        /// <summary>
        /// 現在存活的角色
        /// </summary>
        /// <param name="data">data:{RoomId,UserId}</param>
        /// <returns>新的表 string</returns>
        [HttpDelete]
        public string PatchCurrentPlayer([FromBody]string data)
        {
            var json = JsonConvert.DeserializeObject<RecordUser>(data);
            var sess = HttpContext.Session.GetString(json.RoomId);
            HttpContext.Session.Remove(json.RoomId);
            var index = sess.IndexOf(json.UserId[0]);
            var newSess = sess.Remove(index);
            HttpContext.Session.SetString(json.RoomId, newSess);

            var strJson = _service.CurrentPlayer(json,newSess);
            return strJson;
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
