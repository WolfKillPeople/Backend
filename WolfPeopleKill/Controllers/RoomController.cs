using System;
using System.Collections.Generic;
using System.Linq;
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
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public string AddRoom(string data)
        {
            RoomService _service = new RoomService();
            var result = _service.AddRoom();
            return result;
        }

        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpDelete]
        public IActionResult RemoveRoom(string data)
        {
            RoomService _service = new RoomService();
            _service.RemoveRoom(data);
            return Ok();
        }


    }
}
