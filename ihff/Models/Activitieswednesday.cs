using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ihff.Models
{
    public class Activitywednesday
    {
        public List<Activity> ActivityPatheZaal1 { get; set; }
        public List<Activity> ActivityPatheZaal9 { get; set; }
        public List<Activity> ActivityPatheZaal13 { get; set; }
        public List<Activity> philharmonieVanBeinumZaal { get; set; }
        public List<Activity> PhilharmonieArtiestenfoyer { get; set; }
        public List<Activity> philharmonieKleineZaal { get; set; }
        public List<Activity> toneelschuurFilmzaal1 { get; set; }
        public List<Activity> toneelschuurFilmzaal2 { get; set; }


        //activiteiten dag meegeven in constructor ipv hard coded
        public Activitywednesday(IEnumerable<Activity> activiteiten, int dayOfTheYear)
        {
            ActivityPatheZaal1 = new List<Activity>();
            ActivityPatheZaal9 = new List<Activity>();
            ActivityPatheZaal13 = new List<Activity>();
            philharmonieVanBeinumZaal = new List<Activity>();
            PhilharmonieArtiestenfoyer = new List<Activity>();
            philharmonieKleineZaal = new List<Activity>();
            toneelschuurFilmzaal1 = new List<Activity>();
            toneelschuurFilmzaal2 = new List<Activity>();
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
                        case "Pathe Zaal 1":
                            ActivityPatheZaal1.Add(x);
                            break;
                        case "Pathe Zaal 9":
                            ActivityPatheZaal9.Add(x);
                            break;
                        case "Pathe Zaal 13":
                            ActivityPatheZaal13.Add(x);
                            break;
                        case "Philharmonie Van Beinum zaal":
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
                        default:
                            break;


                    }
                }
            }


        }

        public Activitywednesday()
        {

        }

    }
}