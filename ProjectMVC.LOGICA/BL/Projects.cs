using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.LOGICA.BL
{
    public class Projects
    {
        public List<Models.DB.Projects> GetProjects(int? id, int? tenantId, string userId = null)
        {
            DAL.Models.PROJECTMVCEntities db = new DAL.Models.PROJECTMVCEntities();

            var listProjectsEF = (from _projects in db.Projects select _projects);

            if (id != null)

                listProjectsEF = listProjectsEF.Where(x => x.Id == id);

            if (tenantId != null)

                listProjectsEF = listProjectsEF.Where(x => x.TenantId == tenantId);

            if (!string.IsNullOrEmpty(userId))

                listProjectsEF = (from _projects in listProjectsEF
                                  join _userProjects in db.UserProjects on _projects.Id equals _userProjects.ProjectId
                                  where _userProjects.Id.Equals(userId)
                                  select _projects);

            var listProjects = (from _projects in listProjectsEF
                                select new Models.DB.Projects
                                {
                                    Id = _projects.Id,
                                    Title = _projects.Title,
                                    Details = _projects.Details,
                                    ExpectedCompletionDate = _projects.ExpectedCompletionDate,
                                    TenantId = _projects.TenantId,
                                    CreatedAt = _projects.CreatedAt,
                                    UpdatedAt = _projects.UpdatedAt
                                }).ToList();

            return listProjects;
        }

        public void CreateProjects(string title,
            string details,
            DateTime? expectedCompletionDate,
            int? tenantId)

        {
            DAL.Models.PROJECTMVCEntities db = new DAL.Models.PROJECTMVCEntities();
            db.Projects.Add(new DAL.Models.Projects
            {
                Title = title,
                Details = details,
                ExpectedCompletionDate = expectedCompletionDate,
                TenantId = tenantId,
                CreatedAt = DateTime.Now
            });

            db.SaveChanges();
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="title"></param>
        /// <param name="details"></param>
        /// <param name="expectedCompletionDate"></param>
        public void UpdateProjects(int id,
            string title,
            string details,
            DateTime? expectedCompletionDate)

        {
            DAL.Models.PROJECTMVCEntities db = new DAL.Models.PROJECTMVCEntities();

            var project = db.Projects.Where(x => x.Id == id).FirstOrDefault();
            project.Title = title;
            project.Details = details;
            project.ExpectedCompletionDate = expectedCompletionDate;
            project.UpdatedAt = DateTime.Now;

            db.SaveChanges();
        }
        /// <summary>
        /// Delete Projects
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProjects(int? id)

        {
            DAL.Models.PROJECTMVCEntities db = new DAL.Models.PROJECTMVCEntities();

            var project = db.Projects.Where(x => x.Id == id).FirstOrDefault();

            db.Projects.Remove(project);

            db.SaveChanges();
        }



    }
}
