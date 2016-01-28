using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ihff.Models
{
    public class ActivitiesPerLocation
    {
        public List<List<Activity>> MasterList { get; set; }
        public IEnumerable<string> locations { get; set; }


        //activiteiten dag meegeven in constructor ipv hard coded
        public ActivitiesPerLocation(IEnumerable<Activity> activiteiten, int dayOfTheYear, IEnumerable<string> locations)
        {
            this.locations = locations;
            MasterList = new List<List<Activity>>();
            for (int i = 0; i < locations.Count(); i++)
            {
                List<Activity> sublist = new List<Activity>();
                foreach (Activity activitys in activiteiten)
                {
                    if (activitys.location == locations.ElementAt(i))
                    {
                        sublist.Add(activitys);
                        MasterList.Add(sublist);
                    }
                }
            }
        }

        public ActivitiesPerLocation()
        {

        }

    }
}