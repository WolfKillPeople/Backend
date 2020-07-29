using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;

        }
        /// <summary>
        /// 取得現在所有的房間列表
        /// </summary>
        /// <returns>JSON 沒有的話傳空字串</returns>
        [HttpGet]
        public IEnumerable<Room> CurrentRoom()
        {
            if (HttpContext.Session.GetString("TempRoomId") == "" || HttpContext.Session.GetString("TempRoomId") == null)
            {
                var tempSession = HttpContext.Session.GetString("TempRoomId");
                var result = _service.GetCurrentRoom(tempSession);
                return result;
            }
            else if (HttpContext.Session.GetString("TempRoomId") != "" || HttpContext.Session.GetString("TempRoomId") != null)
            {
                var tempSession = HttpContext.Session.GetString("TempRoomId");
                var result = _service.GetCurrentRoom(tempSession);
                return result;
            }
            return null;

        }

        /// <summary>
        /// 第一次創建房間,增加房間並且增加玩家
        /// </summary>
        /// <param name="data">要被增加的id(房間號,玩家)  data:{RoomId,user}</param>
        /// <returns>id(房間號)</returns>

        [HttpPost]
        public IEnumerable<Room> AddRoom([FromBody] IEnumerable<Room> data)
        {
            IEnumerable<Room> result;
            if (HttpContext.Session.GetString("TempRoomId") == "" || HttpContext.Session.GetString("TempRoomId") == null)
            {
                string session = HttpContext.Session.GetString("TempRoomId");
                result = _service.AddRoom(data, session);
                HttpContext.Session.SetString("TempRoomId", (data.ToList()[0].RoomId + 1).ToString());
                return result;
            }
            else if (HttpContext.Session.GetString("TempRoomId") != "" || HttpContext.Session.GetString("TempRoomId") != null )
            {
                if (HttpContext.Session.GetString("TempRoomId").Contains(data.ToList()[0].RoomId.ToString()) == true)
                {
                    HttpContext.Session.Clear();
                    string _session = "";
                    result = _service.AddRoom(data,_session);
                    HttpContext.Session.SetString("TempRoomId", result.ToList()[0].TempRoomID.ToString());
                    return result;
                }
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("TempRoomId", (data.ToList()[0].RoomId + 1).ToString());
                string session = HttpContext.Session.GetString("TempRoomId");
                result = _service.AddRoom(data, session);
                return result;
            }
            return null;

        }

        /// <summary>
        /// 增加玩家
        /// </summary>
        /// <param name="data">data:{RoomId,userId} user是房間全部的</param>
        /// <returns>status code</returns>

        [HttpPatch]
        public IEnumerable<Room> UpdatePlayer([FromBody] IEnumerable<Room> data)
        {
            var result = _service.UpdatePlayer(data);
            return result;
        }



        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data">要被刪除的id(房間號) data:{RoomId,userId}</param>
        /////// <returns>status code</returns>
        [HttpDelete]
        public IEnumerable<Room> RemoveRoom([FromBody] IEnumerable<Room> data)
        {
            if (HttpContext.Session.GetString("TempRoomId") != "")
            {
                HttpContext.Session.Clear();
                HttpContext.Session.SetString("TempRoomId", data.ToList()[0].RoomId.ToString());
                var session = HttpContext.Session.GetString("TempRoomId");
                var result = _service.DeleteRoom(data, session);
                return result;
            }
            return null;
        }


    }
}
