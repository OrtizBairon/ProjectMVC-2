using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ProjectMVC.Models.BindingModel
{
    public class ProjectsCreateBindingModel  //controlador Projects
    {
        // public string Name { get; set; }
      [Required (ErrorMessage ="The Field Name is required")]
      [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The Field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The Field PercentageAdvance is required")]
        [Display(Name = "PercentageAdvance")]
        public double? PercentageAdvance { get; set; }

        [Required(ErrorMessage = "The Field ExpectedCompletionDate is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime? ExpectedCompletionDate { get; set; }
      
        


    }
}