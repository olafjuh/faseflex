using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity;
using ihff.Models;

namespace ihff.Controllers
{
    public class AgendaBlokkenController : Controller
    {
        //
        // GET: /AgendaBlokken/

        
        private DbRepository repository = new DbRepository();

        public ActionResult Index()
        {
            IEnumerable<Activity> activities = repository.GetActivities();
            //IEnumerable<string> allLocations;
            ihff.Models.ActivitiesPerLocation activitieswednesday = new ActivitiesPerLocation(activities, 1);
            return View(activitieswednesday);


        }

    }
}
