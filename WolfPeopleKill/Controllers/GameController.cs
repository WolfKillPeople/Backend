using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Role> GetRole()
        {
            var _newlist = _service.GetRole();
            return _newlist;
        }

        /// <summary>
        /// 輸贏判定
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public bool WinOrLose(IEnumerable<Role> data)
        {
            var result = _service.WinOrLose(data);
            return result;
        }

    }
}
