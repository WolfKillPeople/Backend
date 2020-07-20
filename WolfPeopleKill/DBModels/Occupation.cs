using System;
using System.Collections.Generic;

namespace DbLibrary.Models
{
    public partial class Occupation
    {
        public int Occupation_ID { get; set; }
        public string Occupation_Name { get; set; }
        public string Occupation_GB { get; set; }
        public string Pic { get; set; }
        public string About { get; set; }
    }
}
