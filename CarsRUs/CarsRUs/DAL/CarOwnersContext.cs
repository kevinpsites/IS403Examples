using CarsRUs.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CarsRUs.DAL
{
    public class CarOwnersContext : DbContext
    {
        public CarOwnersContext() : base("CarOwnersContext")
        {
        }

        public DbSet<Cars> car { get; set; }
        public DbSet<Owner> owner { get; set; }
    }
}