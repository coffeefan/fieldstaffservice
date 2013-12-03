﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace fssdemoserver.Models
{
    public class Tracker
    {
        
        public int TrackerId { get; set; }
        public int PersonId { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public DateTime TrackTime { get; set; }
    }
}