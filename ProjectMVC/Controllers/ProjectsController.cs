using IdentitySample.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;


namespace ProjectMVC.Controllers
{
    [Authorize]
    public class ProjectsController : Controller
    {
        private ApplicationUserManager _usermanager;
        public ApplicationUserManager usermanager
        {
            get { return _usermanager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
            set { _usermanager = value; }
        }

        public ProjectsController(ApplicationUserManager UserManager)
        {
            usermanager = UserManager;
        }

        public ProjectsController()
        {

        }
        // GET: Projects
        public async Task<ActionResult> Index()
        {
            ApplicationUser user = await usermanager.FindByNameAsync(User.Identity.Name);

            LOGICA.BL.Tenants tenants = new LOGICA.BL.Tenants();
            var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

            LOGICA.BL.Projects projects = new LOGICA.BL.Projects();

            var result = await usermanager.IsInRoleAsync(user.Id, "Admin") ?
                projects.GetProjects(null, tenant.Id) : //si es admin consulta todos los proyectos de la organizacion
                projects.GetProjects(null, tenant.Id, user.Id); // si es miembro consulta los proyectos de las organizacionde que le pertenezcan 

            var listProjects = result.Select(X => new LOGICA.Models.ViewModels.ProjectsIndexViewModels
            {
                Id = X.Id,
                Title = X.Title,
                Details = X.Details,
                ExpectedCompletionDate = X.ExpectedCompletionDate,
                CreatedAt = X.CreatedAt,
                UpdatedAt = X.UpdatedAt

            }).ToList();

            listProjects = tenant.Plan.Equals("Premium") ?
                listProjects :
                listProjects.Take(1).ToList();


            return View(listProjects);
            //return View("Create");
        }
        //[ActionName ("Create")]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<ActionResult> Create(LOGICA.Models.BindingModels.ProjecCreatetBindingModel Model)
        {

            if (ModelState.IsValid)
            {
                ApplicationUser user = await usermanager.FindByNameAsync(User.Identity.Name);

                LOGICA.BL.Tenants tenants = new LOGICA.BL.Tenants();
                var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

                LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
                projects.CreateProjects(Model.Title, Model.Details, Model.ExpectedCompletionDate, tenant.Id);

                return RedirectToAction("Index");
            }

            return View(Model);
        }

        public ActionResult Edit(int? id)
        {
            LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
            var project = projects.GetProjects(id, null).FirstOrDefault(); //no toma una lista sino, un objeto

            var projectBindinModel = new LOGICA.Models.BindingModels.ProjectsEditBindingModel
            {
                Id = project.Id,
                Title = project.Title,
                Details = project.Details,
                ExpectedCompletionDate = project.ExpectedCompletionDate,

            };
            return View(projectBindinModel);
        }
        [HttpPost]
        public ActionResult Edit(LOGICA.Models.BindingModels.ProjectsEditBindingModel model)
        {
            if (ModelState.IsValid)
            {
                LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
                projects.UpdateProjects(model.Id,
                    model.Title,
                    model.Details,
                    model.ExpectedCompletionDate);

                return RedirectToAction("Index");

            }
            return View(model);
        }

        public ActionResult Detail(int? id)
        {

            LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
            var project = projects.GetProjects(id, null).FirstOrDefault(); //no toma una lista sino, un objeto

            var projectDetailViewModel = new LOGICA.Models.ViewModels.ProjectsDetailsViewModels
            {

                Title = project.Title,
                Details = project.Details,
                ExpectedCompletionDate = project.ExpectedCompletionDate,
                CreatedAt = project.CreatedAt,
                UpdatedAt = project.UpdatedAt

            };
            return View(projectDetailViewModel);

        }

        public ActionResult Delete(int? id)
        {
            LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
            projects.DeleteProjects(id);

            return RedirectToAction("Index");
        }

    }
}