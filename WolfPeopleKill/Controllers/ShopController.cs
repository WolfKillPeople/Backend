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
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;
        public ShopController(IShopService service)
        {
            _service = service;
        }
        /// <summary>
        /// get project
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<Shop> GetShop()
        {
            var pro = _service.GetShop();
            return pro;

        }
    }

}
