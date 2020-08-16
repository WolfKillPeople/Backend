using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using WolfPeopleKill.Interfaces;
using WolfPeopleKill.Models;
using System.Threading.Tasks;


namespace WolfPeopleKill.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _service;
        private static IEnumerable<VotePlayers> result;
        public GameController(IGameService service)
        {
            _service = service;
        }

        /// <summary>
        /// 進房間時每一個玩家的資訊
        /// </summary>
        /// <param name="data">data:{RoomId}</param>
        /// <returns>JSON GamePlay</returns>
        [HttpPost]
        public IEnumerable<GamePlay> GetPlayers(IEnumerable<GamePlay> data)
        {
            return _service.RoomGetPlayers(data);
        }

        /// <summary>
        /// 隨機分配角色
        /// </summary>
        /// <param name="data">data:{RoomId}</param>
        /// <returns>IEnumerable JSON</returns>
        [HttpPost]
        public IEnumerable<GamePlay> GetRole(IEnumerable<GamePlay> data)
        {
            var newline = _service.GetRole(data);
            return newline;
        }


        /// <summary>
        /// 每一次死亡都要回傳現在存活的角色
        /// </summary>
        /// <param name="data">data:{RoomId,Player,isAlive}</param>
        /// <returns>status code</returns>
        [HttpPatch]
        public IActionResult PatchCurrentPlayer([FromBody] IEnumerable<KillPeoPle> data)
        {
            return Ok(_service.PatchCurrentPlayer(data));
        }
        /// <summary>
        /// 女巫救人,回傳所有活著的玩家
        /// </summary>
        /// <param name="data">data:{RoomId,Player,Alive}</param>
        /// <returns>status code</returns>

        [HttpPatch]
        public IActionResult Savepeople([FromBody] IEnumerable<KillPeoPle> data)
        {
            return Ok(_service.Savepeople(data));
        }
        /// <summary>
        /// 預言家查玩家
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public List<Models.Occupation> Observer(KillPeoPle data)
        {
            var newline = _service.Observer(data);
            //return Ok(newline);

            return newline;
        }

        /// <summary>
        /// 輸贏判定
        /// </summary>
        /// <param name="data">data:{name} Required</param>
        /// <returns>(string) Which one is win or not yet</returns>
        [HttpPost]
        public IEnumerable<Role.Result> WinOrLose([FromBody] IEnumerable<Role> data)
        {
            var result =  _service.WinOrLose(data);
            return result;
        }

        /// <summary>
        /// 投票
        /// </summary>
        /// <param name="data">data:{RoomID,User,Vote} Required</param>
        [HttpPost]
        public void Vote([FromBody] IEnumerable<VotePlayers> data)
        {
            if (result != Enumerable.Empty<VotePlayers>().ToList())
            {
                result = Enumerable.Empty<VotePlayers>().ToList();
            }
            result = _service.Votes(data);
        }
        /// <summary>
        /// 投票結果
        /// </summary>
        /// <returns>JSON</returns>
        [HttpGet]
        public IEnumerable<VotePlayers> VoteResult()
        {
            return result;
        }

        /// <summary>
        /// 玩家離開房間
        /// </summary>
        [HttpPost]
        public IActionResult OutToRoom(OutToRoom data)
        {
            return Ok(_service.OutToRoom(data));
        }

        /// <summary>
        /// 記錄勝場
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult GameWin(GameWin data)
        {
            return Ok(_service.GameWin(data));
        }
    }
}
