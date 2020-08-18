using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[Authorize]
    public class UserRegisterController : ControllerBase
    {
        private readonly IAuthenticateService _authService;
        private readonly IUserService _service;

        public UserRegisterController(IUserService service,IAuthenticateService authService)
        {
            _service = service;
            _authService = authService;
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

        /// <summary>
        /// JWT token
        /// </summary>
        /// <param name="request"></param>
        /// <returns>token</returns>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] LoginDTO request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }
            string token;
            if (_authService.IAuthenticated(request,out token))
            {
                return Ok(token);
            }
            return BadRequest("Invalid Request");
        }
    }
}
