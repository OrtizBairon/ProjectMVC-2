using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.LOGICA.BL
{
    public class Projects
    {
        public void CreateProjects(string title,
            string details,
            DateTime? expectedCompletionDate,
            int? tenantId)

        {
            DAL.Models.PROJECTMVCEntities db = new DAL.Models.PROJECTMVCEntities();
            db.Projects.Add(new DAL.Models.Projects
            {
             Title =title,
             Details = details,
             ExpectedCompletionDate=expectedCompletionDate,
             TenantId = tenantId,
             CreatedAt= DateTime.Now
            });

            db.SaveChanges();
        }



        
    }
}
