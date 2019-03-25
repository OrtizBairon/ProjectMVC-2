using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectMVC.Models
{
    public class Projects
    {
        public  int  Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public double? PercentageAdvance { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        DateTime? CreatedAT { get; set; }
        DateTime? UpdateAT { get; set; }
        public string Details { get; set; }

    }
}