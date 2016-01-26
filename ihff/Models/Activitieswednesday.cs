using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Activitieswednesday
    {
        public List<Activities> activitiesPatheZaal1 { get; set; }
        public List<Activities> activitiesPatheZaal9 { get; set; }
        public List<Activities> activitiesPatheZaal13 { get; set; }
        public List<Activities> philharmonieVanBeinumZaal { get; set; }
        public List<Activities> PhilharmonieArtiestenfoyer { get; set; }
        public List<Activities> philharmonieKleineZaal { get; set; }
        public List<Activities> toneelschuurFilmzaal1 { get; set; }
        public List<Activities> toneelschuurFilmzaal2 { get; set; }


        //activiteiten dag meegeven in constructor ipv hard coded
        public Activitieswednesday(IEnumerable<Activities> activiteiten, int dayOfTheYear)
        {
            activitiesPatheZaal1 = new List<Activities>();
            activitiesPatheZaal9 = new List<Activities>();
            activitiesPatheZaal13 = new List<Activities>();
            philharmonieVanBeinumZaal = new List<Activities>();
            PhilharmonieArtiestenfoyer = new List<Activities>();
            philharmonieKleineZaal = new List<Activities>();
            toneelschuurFilmzaal1 = new List<Activities>();
            toneelschuurFilmzaal2 = new List<Activities>();
            foreach (Activities x in activiteiten)
            {
                //loactie id in db beter
                /*if (locatie == "Pathe Zaal 1" && dag == x.startTime.DayOfYear)
                {
                    activitiesPatheZaal1.Add(x);
                }*/
                if (dayOfTheYear == x.startTime.DayOfYear)
                {
                    switch (x.location)
                    {
                        case "Pathe Zaal 1":
                            activitiesPatheZaal1.Add(x);
                            break;
                        case "Pathe Zaal 9":
                            activitiesPatheZaal9.Add(x);
                            break;
                        case "Pathe Zaal 13":
                            activitiesPatheZaal13.Add(x);
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

        public Activitieswednesday()
        {

        }

    }
}