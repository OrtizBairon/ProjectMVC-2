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
        public ActionResult Index()
        {
            return View();
            //return View("Create");
        }
        //[ActionName ("Create")]
        public ActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task <ActionResult> Create(LOGICA.Models.BindingModels.ProjecCreatetBindingModel Model)
        {

            if (ModelState.IsValid) 
            {
                ApplicationUser user = await usermanager.FindByNameAsync(User.Identity.Name);

                LOGICA.BL.Tenants tenants = new LOGICA.BL.Tenants();
                var tenant = tenants.GetTenants(user.Id).FirstOrDefault();

                LOGICA.BL.Projects projects = new LOGICA.BL.Projects();
                projects.CreateProjects(Model.Title,Model.Details,Model.ExpectedCompletionDate,tenant.Id);

                return RedirectToAction("Index");

                //string name = model.Name;
                //string title = model.Title;
                //string Details = model.Details;
                //double? PercentageAdvance = model.PercentageAdvance;
                //DateTime? ExpectedCompletionDate = model.ExpectedCompletionDate;


                //return RedirectToAction("index");


            }

            return View(Model);
        }

        //    //breackpoint
        //    string name = model.Name;

        //    var viewModel = new Models.ViewModels.CreateViewModel
        //    {
        //        Name = model.Name
        //    };
        //    return View("Show", viewModel);


    }
}