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
    [Route("api/[controller]")]
    [ApiController]
    public class BuyController : ControllerBase
    {
        private readonly IBuyService _service;
        public BuyController(IBuyService service)
        {
            _service = service;
        }
        /// <summary>
        /// get Detail
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Buy> GetBuy()
        {
            var pro = _service.GetBuy();
            return pro;

        }
        /// <summary>
        /// 新增購物資料
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NewBuy(Buy data)
        {
            return Ok(_service.NewBuy(data));

        }
    }
}
