using MovieShopApp.ViewModel;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MovieShopApp.Models
{
    public class Movie 
    {
        public int ID { get; set; }

        [DisplayName("Title(from IMDB)")]
        public string Title { get; set; }

        [DefaultValue(0)]
        public float Rating { get; set; }

        [DataType(DataType.MultilineText)]
        public string Plot { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime TimeAdded { get; set; }

    }
}