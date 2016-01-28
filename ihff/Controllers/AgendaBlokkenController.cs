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
            IEnumerable<string> locations = repository.GetLocations();
            //IEnumerable<string> allLocations;
            int dayOfTheYearFirstday = activities.First().startTime.DayOfYear;
            ActivitiesPerLocation activitieswednesday = new ActivitiesPerLocation(activities, dayOfTheYearFirstday, locations);
            return View(activitieswednesday);
        }
        public ActionResult AgendaOfADay(int day)
        {
            IEnumerable<Activity> activities = repository.GetActivities();
            int dayOfTheYearFirstday = activities.First().startTime.DayOfYear;
            int dayoftheyear = dayOfTheYearFirstday + day;
            IEnumerable<string> locations = repository.GetLocations();
            ActivitiesPerLocation activitiesOfAday = new ActivitiesPerLocation(activities, dayoftheyear, locations);
            return View("Index",activitiesOfAday);
        }

    }
}
