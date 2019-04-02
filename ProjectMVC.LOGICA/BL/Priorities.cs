using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectMVC.LOGICA.BL
{
    public class Priorities
    {

        /// <summary>
        /// GET PRIORITIES
        /// </summary>
        /// <returns></returns>
        public List<Models.DB.Priorities> GetPriorities()
        {
            DAL.Models.PROJECTMVCEntities _context = new DAL.Models.PROJECTMVCEntities();
            var listpriorities = (from _priorities in _context.Priorities
                                  where _priorities.Active == true
                                  select new Models.DB.Priorities
                                  {
                                      Id = _priorities.Id,
                                      Name = _priorities.Name,
                                      Active = _priorities.Active

                                  }).ToList();

            return listpriorities;
        }
    }
}
