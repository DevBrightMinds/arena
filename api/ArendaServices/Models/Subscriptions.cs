using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArendaServices.Models
{
    public class Subscriptions
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        public Nullable<int> Phone { get; set; }
        [Required]
        public string Message { get; set; }
    }
}