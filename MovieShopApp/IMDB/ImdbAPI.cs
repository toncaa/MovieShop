using MovieShopApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieShopApp.IMDB
{
    public class ImdbAPI
    {

        private static ImdbAPI singleton;
        private string WebServiceAddress = "http://www.omdbapi.com/?t=";


        public static ImdbAPI Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new ImdbAPI();
                return singleton;
            }
            set
            {
                singleton = value;
            }
        }

        private ImdbAPI() { }

        public async Task<Movie> GetMovieByTitle(string title)
        {
            var client = new HttpClient
            {
                BaseAddress =
                new Uri(WebServiceAddress + title)
            };
            string json = await client.GetStringAsync(client.BaseAddress);
            dynamic data = JObject.Parse(json);
            Console.WriteLine(data);

            Movie movie = new Movie();
            movie.ImageUrl = data.Poster;
            movie.Plot = data.Plot;
            movie.Title = data.Title;
            movie.Rating = data.imdbRating;

            return movie;
        }

    }
}