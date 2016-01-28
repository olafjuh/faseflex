using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class WishlistItem
    {
        public int Id { get; set; }
        public int wishID { get; set; }
        public int actID { get; set; }

        [Required(ErrorMessage = "Aantal personen is een verplicht veld.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Aantal personen must be numeric")]
        [Range(0, 15)]
        [Display(Name = "Aantal personen: ")]
        public int? persons { get; set; }

        [Required(ErrorMessage = "Naam is een verplicht veld.")]
        [Display(Name = "Naam: ")]
        public string name { get; set; }

        [Required(ErrorMessage = "Type is een verplicht veld.")]
        [Display(Name = "Type: ")]
        public string type { get; set; }

        [Required(ErrorMessage = "Start tijd is een verplicht veld.")]
        [Display(Name = "Start tijd: ")]
        public DateTime startTime { get; set; }

        [Required(ErrorMessage = "Eind tijd is een verplicht veld.")]
        [Display(Name = "Eind tijd: ")]
        public DateTime endTime { get; set; }

        [Required(ErrorMessage = "Locatie is een verplicht veld.")]
        [Display(Name = "Locatie: ")]
        public string location { get; set; }
        

        public WishlistItem(int Id, int wishID, int actID, int persons, string name, string type, DateTime startTime, DateTime endTime, string location)
        {
            this.Id = Id;
            this.wishID = wishID;
            this.actID = actID;
            this.persons = persons;
            this.name = name;
            this.type = type;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
        }

        public WishlistItem()
        {

        }
    }
}