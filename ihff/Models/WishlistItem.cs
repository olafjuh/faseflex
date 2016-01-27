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
        [Display(Name = "Aantal personen: ")]
        public int persons { get; set; }
        public string name { get; set; }

        public string type { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string location { get; set; }
        
        
        //public int kids { get; set; }

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
            
            //this.kids = kids;

        }

        public WishlistItem()
        {

        }
    }
}