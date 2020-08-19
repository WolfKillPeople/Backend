using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Design;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;

namespace WolfPeopleKill.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;
        static StringBuilder TempRoomId = new StringBuilder("");
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

            if (TempRoomId.ToString() == "" || TempRoomId == null)
            {
                var result = _service.GetCurrentRoom(TempRoomId);
                return result;
            }
            else if (TempRoomId.ToString() != "" || TempRoomId != null)
            {
                var result = _service.GetCurrentRoom(TempRoomId);
                return result;
            }
            return null;

        }

        /// <summary>
        /// 第一次創建房間,增加房間並且增加玩家
        /// </summary>
        /// <param name="data">要被增加的id(房間號,玩家)  data:{RoomId,user}</param>
        /// <returns>id(房間號)</returns>
        //[HttpPost]
        //public IEnumerable<Room> AddRoom([FromBody] IEnumerable<Room> data)
        //{
        //    TempRoomId.Clear();
        //    var result = _service.AddRoom(data, TempRoomId);
        //    TempRoomId.Append(result.ToList()[0].TempRoomID);
        //    return result;
        //}

        /// <summary>
        /// 增加玩家
        /// </summary>
        /// <param name="data">data:{RoomId,userId} user是房間全部的</param>
        /// <returns>status code</returns>
        [HttpPatch]
        public IEnumerable<Room> UpdatePlayer([FromBody] IEnumerable<Room> data)
        {
            var result = _service.UpdatePlayer(data, TempRoomId);
            return result;
        }



        /// <summary>
        /// 減少房間
        /// </summary>
        /// <param name="data">要被刪除的id(房間號) data:{RoomId}</param>
        /// <returns>JSON {TempRoomId}</returns>
        [HttpDelete]
        public IEnumerable<Room> RemoveRoom([FromBody] IEnumerable<Room> data)
        {
            TempRoomId.Clear();
            var result = _service.DeleteRoom(data, TempRoomId);
            TempRoomId.Append(result[0].TempRoomID);
            return result;
        }


    }
}
