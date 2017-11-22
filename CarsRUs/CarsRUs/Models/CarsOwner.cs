using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarsRUs.Models;

namespace CarsRUs.Models
{
    public class CarsOwner
    {
        public Cars cars { get; set; }
        public Owner owner { get; set; }
    }
}