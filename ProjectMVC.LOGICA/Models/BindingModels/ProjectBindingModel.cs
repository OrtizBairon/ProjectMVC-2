using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.LOGICA.Models.BindingModels
{
    public class ProjecCreatetBindingModel
    {

        [Required(ErrorMessage = "The Field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }


        [Required(ErrorMessage = "The Field ExpectedCompletionDate is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime? ExpectedCompletionDate { get; set; }
    }

    public class ProjectsEditBindingModel
    {
        [Required(ErrorMessage = "The Field Id is required")]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The Field Title is required")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "The Field Details is required")]
        [Display(Name = "Details")]
        public string Details { get; set; }

        [Required(ErrorMessage = "The Field ExpectedCompletionDate is required")]
        [Display(Name = "ExpectedCompletionDate")]
        public DateTime? ExpectedCompletionDate { get; set; }

    }

}
