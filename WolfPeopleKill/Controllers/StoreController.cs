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
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _service;
        public StoreController(IStoreService service)
        {
            _service = service;
        }
        [HttpPost]
        public List<Store> PostScore(Store data)
        {
            var pro = _service.NewScore(data);
            return pro;
        }
    }
}