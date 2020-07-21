﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.DBModels
{
    public partial class Room
    {
        [Key]
        public int RoomId { get; set; }
        public string? Player1 { get; set; }
        public string? Player2 { get; set; }
        public string? Player3 { get; set; }
        public string? Player4 { get; set; }
        public string? Player5 { get; set; }
        public string? Player6 { get; set; }
        public string? Player7 { get; set; }
        public string? Player8 { get; set; }
        public string? Player9 { get; set; }
        public string? Player10 { get; set; }
    }
}
