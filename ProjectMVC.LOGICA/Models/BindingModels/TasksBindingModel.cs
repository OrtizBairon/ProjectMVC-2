using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVC.LOGICA.Models.BindingModels
{
    public class TasksCreateBindingModel
    {

        [Display(Name = "Title")]
        [Required(ErrorMessage = " the field title is requeried")]
        public string Title { get; set; }

        [Display(Name = "Details")]
        [Required(ErrorMessage = " the field Details is requeried")]
        public string Details { get; set; }

        [Display(Name = "ExpirationDate")]
        [Required(ErrorMessage = " the field ExpirationDate is requeried")]
        public DateTime? ExpirationDate { get; set; }

        [Display(Name = "IsCompleted")]
        [Required(ErrorMessage = " the field IsCompleted is requeried")]
        public bool IsCompleted { get; set; }

        [Display(Name = "Effort")]
        [Required(ErrorMessage = " the field Effort is requeried")]
        public int? Effort { get; set; }

        [Display(Name = "RemainingWork")]
        [Required(ErrorMessage = " the field Remaining Work is requeried")]
        public int? RemainingWork { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = " the field State is requeried")]
        public int? StateId { get; set; }

        [Display(Name = "Activity")]
        [Required(ErrorMessage = " the field Activity is requeried")]
        public int? ActivityId { get; set; }

        [Display(Name = "Priority")]
        [Required(ErrorMessage = " the field Priority is requeried")]
        public int? PriorityId { get; set; }

        [Display(Name = "project")]
        [Required(ErrorMessage = " the field project is requeried")]
        public int? projectId { get; set; }
    }
}
