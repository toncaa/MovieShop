using System.ComponentModel.DataAnnotations;

namespace MovieShopApp.ViewModel
{
    public class OrderListViewModel
    {
        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public int OrderId { get; set; }

        public string Plot { get; set; }
        public float Rating { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }

        public OrderListViewModel(int orderId, string imgUrl, string plot, float rating, double price)
        {
            OrderId = orderId;
            ImageUrl = imgUrl;
            Plot = plot;
            Rating = rating;
            Price = price;
        }
    }
}