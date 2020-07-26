using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;


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
        /// <param name="data">data:{RoomId}</param>
        /// <returns>IEnumerable JSON</returns>
        [HttpPost]
        public IEnumerable<GamePlay> GetRole(IEnumerable<GamePlay> data)
        {
            var newline = _service.GetRole(data);

            return newline;
        }



        /// <summary>
        /// 每一次死亡都要回傳現在存活的角色
        /// </summary>
        /// <param name="data">data:{RoomId,Player,Alive}</param>
        /// <returns>status code</returns>

        [HttpPatch]
        public IActionResult PatchCurrentPlayer([FromBody] IEnumerable<Room> data)
        {
            return Ok(_service.PatchCurrentPlayer(data));
        }

        /// <summary>
        /// 輸贏判定
        /// </summary>
        /// <param name="data">Occupationid,isGood Required</param>
        /// <returns>(string) Which one is win or not</returns>
        [HttpPost]
        public string WinOrLose([FromBody] IEnumerable<Role> data)
        {
            var result = _service.WinOrLose(data);
            return result;
        }

    }
}
