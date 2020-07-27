using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.DBModels
{
    public partial class Occupation
    {
        [Key]
        public int OccupationId { get; set; }
        public string Occupation_Name { get; set; }
        public string Occupation_GB { get; set; }
        public string Pic { get; set; }
        public string About { get; set; }
    }
}
