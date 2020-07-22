using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WolfPeopleKill.DBModels
{
    public partial class GameRoom
    {
        public int RoomId { get; set; }
        public string Players { get; set; }
        public int? OccupationId { get; set; }
        public string IsAlive { get; set; }

       
        public int Id { get; set; }
    }
}
