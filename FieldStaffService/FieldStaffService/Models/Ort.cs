using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FieldStaffService.Models
{
    public class Ort
    {
        public int ortid { get; set; }
        public string plz { get; set; }
        public string bezeichnung { get; set; }
        public int kantonid { get; set; }
    }
}