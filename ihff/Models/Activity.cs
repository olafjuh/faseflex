﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ihff.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public string location { get; set; }
        public int seats { get; set; }
        public int? seatsReserved { get; set; }

        public Activity(string name, string type, DateTime startTime, DateTime endTime, string location, int seats, int seatsReserved)
        {
            this.Id = Id;
            this.name = name;
            this.type = type;
            this.startTime = startTime;
            this.endTime = endTime;
            this.location = location;
            this.seats = seats;
            this.seatsReserved = seatsReserved;
        }

        public Activity()
        {

        }
        
    }
}