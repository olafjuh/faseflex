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
        public List<Activity> ActivityPatheZaal1 { get; set; }
        public List<Activity> ActivityPatheZaal9 { get; set; }
        public List<Activity> ActivityPatheZaal13 { get; set; }
        public List<Activity> philharmonieVanBeinumZaal { get; set; }
        public List<Activity> PhilharmonieArtiestenfoyer { get; set; }
        public List<Activity> philharmonieKleineZaal { get; set; }
        public List<Activity> toneelschuurFilmzaal1 { get; set; }
        public List<Activity> toneelschuurFilmzaal2 { get; set; }
        public List<Activity> partonaatKleinezaal { get; set; }


        //activiteiten dag meegeven in constructor ipv hard coded
        public ActivitiesPerLocation(IEnumerable<Activity> activiteiten, int dayOfTheYear)
        {
            ActivityPatheZaal1 = new List<Activity>();
            ActivityPatheZaal9 = new List<Activity>();
            ActivityPatheZaal13 = new List<Activity>();
            philharmonieVanBeinumZaal = new List<Activity>();
            PhilharmonieArtiestenfoyer = new List<Activity>();
            philharmonieKleineZaal = new List<Activity>();
            toneelschuurFilmzaal1 = new List<Activity>();
            toneelschuurFilmzaal2 = new List<Activity>();
            partonaatKleinezaal = new List<Activity>();
            foreach (Activity x in activiteiten)
            {
                //loactie id in db beter
                /*if (locatie == "Pathe Zaal 1" && dag == x.startTime.DayOfYear)
                {
                    ActivityPatheZaal1.Add(x);
                }*/
                if (dayOfTheYear == x.startTime.DayOfYear)
                {
                    switch (x.location)
                    {
                        case "Pathé - zaal 1":
                            ActivityPatheZaal1.Add(x);
                            break;
                        case "Pathé - zaal 9":
                            ActivityPatheZaal9.Add(x);
                            break;
                        case "Pathé - zaal 13":
                            ActivityPatheZaal13.Add(x);
                            break;
                        case "Philharmonie - van Beinum Zaal":
                            philharmonieVanBeinumZaal.Add(x);
                            break;
                        case "Philharmonie Artiestenfoyer":
                            PhilharmonieArtiestenfoyer.Add(x);
                            break;
                        case "Philharmonie Kleine zaal":
                            philharmonieKleineZaal.Add(x);
                            break;
                        case "Toneelschuur Filmzaal 1":
                            toneelschuurFilmzaal1.Add(x);
                            break;
                        case "Toneelschuur Filmzaal 2":
                            toneelschuurFilmzaal2.Add(x);
                            break;
                        case "Patronaat – Kleine zaal":
                            partonaatKleinezaal.Add(x);
                            break;

                        default:
                            break;


                    }
                }
            }


        }

        public ActivitiesPerLocation()
        {

        }

    }
}