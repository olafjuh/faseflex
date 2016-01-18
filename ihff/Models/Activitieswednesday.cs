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
        public IEnumerable<Activiteit> activitiesPatheZaal1 { get; set; }

        public Activitieswednesday(IEnumerable<Activiteit> activiteiten)
        {
                activitiesPatheZaal1 = activiteiten;
               
            
        }

        public Activitieswednesday()
        {

        }

    }
}