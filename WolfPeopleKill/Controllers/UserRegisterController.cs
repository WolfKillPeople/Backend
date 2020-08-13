using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserRegisterController : ControllerBase
    {

        private readonly IUserService _service;

        public UserRegisterController(IUserService service)
        {
            _service = service;
        }
        /// <summary>
        /// 更新圖片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult postpic(User data)
        {
            return Ok(_service.PatchUserPic(data));

        }

        /// <summary>
        /// 登入抓照片
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult LoingPostpic(LoingPostpic data)
        {
            return Ok(_service.LoingPostpic(data));

        }
        /// <summary>
        /// 加減積分
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult postwin(UserWin data)
        {
            return Ok(_service.PostWin(data));

        }

        /// <summary>
        /// 讀取積分
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GetWin(UserWin data)
        {
            return Ok(_service.GetWin(data));

        }
    }
}
