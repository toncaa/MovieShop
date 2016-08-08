using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShopApp.Models
{
    public enum OrderType
    {
         PreOrder,
         PostOrder
    }

    public class Order
    {
        public int ID { get; set; }

        public OrderType Type { get; set; }

        public int MovieId { get; set; }

        public string UserId { get; set; }

    }
}