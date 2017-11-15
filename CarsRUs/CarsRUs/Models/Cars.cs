using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CarsRUs.Models
{
    [Table("Cars")]
    public class Cars
    {
        [Key]
        public int carID { get; set; }

        [Required(ErrorMessage = "The Car name is required")]
        [DisplayName("Car Name")]
        [StringLength(30)]
        public String carName { get; set; }

        public int? ownerID { get; set; }
    }
}