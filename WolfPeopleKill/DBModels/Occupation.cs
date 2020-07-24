using System;
using System.Collections.Generic;

namespace WolfPeopleKill.DBModels
{
    public partial class Occupation
    {
        public int OccupationId { get; set; }
        public string Occupation_Name { get; set; }
        public string Occupation_GB { get; set; }
        public string Pic { get; set; }
        public string About { get; set; }
    }
}
