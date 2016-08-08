using Microsoft.AspNet.Identity;
using MovieShopApp.Models;
using MovieShopApp.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace MovieShopApp.Controllers
{
   [Authorize]
    public class CartController : Controller
    {
        MovieShopAppContext db = new MovieShopAppContext();

        // GET: Cart
        public ActionResult Index()
        {
            List<OrderListViewModel> orderList = new List<OrderListViewModel>();
            string userId = User.Identity.GetUserId();
            db.Orders.AsQueryable()
                    .Where(x => x.UserId == userId && x.Type == OrderType.PreOrder)
                    .ForEach(x => {
                        Movie movie = (Movie)db.Movies.Where(y => x.MovieId == y.ID).FirstOrDefault();
                        if(movie != null)orderList.Add(new OrderListViewModel(x.ID, movie.ImageUrl, movie.Plot, movie.Rating, movie.Price));
                        });


            return View("OrderList", orderList);
        }


        public ActionResult AddOrder(int movieId)
        {
            string userId = User.Identity.GetUserId();

            Order order = new Order();
            order.MovieId = movieId;
            order.UserId = userId;
            order.Type = OrderType.PreOrder;

            db.Orders.Add(order);


            db.SaveChanges();
            return RedirectToAction("Index", "Movies");

        }

        public ActionResult RemoveOrder(int orderId)
        {
            Order order = db.Orders.Where(x => x.ID == orderId).FirstOrDefault();
            db.Orders.Remove(order);
            db.SaveChanges();

            //return RedirectToAction("Index", "Movies");
             return RedirectToAction("Index", "Cart");

        }

        public ActionResult DoTheOrder()
        {
            string userId = User.Identity.GetUserId();

            db.Orders.ForEach(x => x.Type = OrderType.PostOrder);
            db.SaveChanges();

            return RedirectToAction("Index", "Cart");

        }



    }
}