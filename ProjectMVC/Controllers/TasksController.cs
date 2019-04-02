using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectMVC.Controllers
{
    public class TasksController : Controller
    {
        // GET: Tasks
        public ActionResult Index(int? projectId)
        {
            LOGICA.BL.Tasks tasks = new LOGICA.BL.Tasks();
            var listTasks = tasks.GetTasks(projectId, null);

            var listTasksViewModel = listTasks.Select(x => new LOGICA.Models.ViewModels.TasksIndexViewModels
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                ExpirationDate = x.ExpirationDate,
                IsCompleted = x.IsCompleted,
                Effort = x.Effort,
                RemainingWork = x.RemainingWork,
                State = x.states.Name,
                Activity = x.Activities.Name,
                Priority = x.Priorities.Name,


            }).ToList();
    

            ViewBag.projectId = projectId;

            return View(listTasksViewModel);
        }

        public ActionResult Create(int? projectId)
        {

            var tasksBindingModel = new LOGICA.Models.BindingModels.TasksCreateBindingModel
            {
                projectId = projectId
            };

            LOGICA.BL.States states = new LOGICA.BL.States();
            ViewBag.States = states.GetStates();

            LOGICA.BL.Activities activities = new LOGICA.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            LOGICA.BL.Priorities priorities = new LOGICA.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorities();

            return View(tasksBindingModel);
        }
    }
}