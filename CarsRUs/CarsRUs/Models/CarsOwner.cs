using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsRUs.Models
{
    public class CarsOwner
    {
        public Cars cars { get; set; }
        public Owners owner { get; set; }
    }
}