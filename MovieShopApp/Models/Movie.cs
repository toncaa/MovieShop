using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieShopApp.Models
{
    public class Movie 
    {
        public int ID { get; set; }

        [Required()]
        public string Name { get; set; }

        [DefaultValue(0)]
        public float Rating { get; set; }

        public string Description { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        [DataType(DataType.Url)]
        public string Imdb { get; set; }
        
        [DisplayName("Added")]
        [DataType(DataType.DateTime)]
        public DateTime TimeAdded { get; set; }
    }
}