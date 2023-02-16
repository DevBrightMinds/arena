using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArendaServices.Models
{
    public class Articles
    {
        public int ID { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string ArticleName { get; set; }
        public Nullable<int> IsPublished { get; set; }
        [Required]
        public string DateCreated { get; set; }
        [Required]
        public string ImageUrl { get; set; }
    }
}