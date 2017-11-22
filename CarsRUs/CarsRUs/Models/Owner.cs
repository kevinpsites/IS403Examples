using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarsRUs.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int? ownerID { get; set; }

        [Required(ErrorMessage = "The Owner Last name is required")]
        [DisplayName("Owner Last Name")]
        [StringLength(30)]
        public String ownerLastName { get; set; }

        [Required(ErrorMessage = "The Owner First name is required")]
        [DisplayName("Owner First name")]
        [StringLength(30)]
        public String ownerFirstName { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        [DisplayName("Email")]
        [StringLength(50)]
        [EmailAddress]
        public String ownerEmail { get; set; }

    }
}