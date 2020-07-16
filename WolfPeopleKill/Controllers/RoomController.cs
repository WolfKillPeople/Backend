using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        public RoomController(ILogger<RoomController> logger)
        {
            _logger = logger;
        }

        
        /// <summary>
        /// 增加房間
        /// </summary>
        /// <returns>id(房間號)</returns>
        [HttpPost]
        public IActionResult AddRoom([FromBody]string data)
        {
            HttpContext.Session.SetString(data,data);
            return Ok();
        }

        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data">要被刪除的id(房間號)</param>
        /// <returns>status code 200 is ok</returns>
        [HttpDelete]
        public IActionResult RemoveRoom([FromBody]string data)
        {
            HttpContext.Session.Remove(data);
            return Ok();
        }
    }
}
