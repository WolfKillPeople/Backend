using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WolfPeopleKill.DBModels
{
    public partial class Occupation
    {
        [Key]
        public int OccupationId { get; set; }
        public string OccupationName { get; set; }
        public string OccupationGb { get; set; }
        public string Pic { get; set; }
        public string About { get; set; }
    }
}
