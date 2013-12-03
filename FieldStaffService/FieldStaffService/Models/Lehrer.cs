using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldStaffService.Models
{
    public class Lehrer
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int kundeid { get; set; }
        public string anrede{ get; set; }
        public string vorname{ get; set; }
        public string name{ get; set; }
        public string telp{ get; set; }
        public string telg{ get; set; }
        public string email{ get; set; }
        public string bemerkung{ get; set; }
        public int kstatusid{ get; set; }
        public int beziehungid { get; set; }

        public int? festterminverwaltungid{ get; set; }
        
        public int? festarbeiterid{ get; set; }
        public string festbenutzername{ get; set; }
        public int? festterminartid{ get; set; }
        public DateTime? festterminstart{ get; set; }
        public DateTime? festterminende { get; set; }

        public int? vonbisterminverwaltungid{ get; set; }
        public int? vonbisarbeiterid{ get; set; }
        public string vonbisbenutzername{ get; set; }
        public int? vonbisterminartid{ get; set; }
        public DateTime? vonbisterminstart { get; set; }
        public DateTime? vonbisterminende { get; set; }
    }
}