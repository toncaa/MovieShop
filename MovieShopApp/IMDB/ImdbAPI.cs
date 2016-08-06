using MovieShopApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace MovieShopApp.IMDB
{
    public static class ImdbAPI
    {
        public static string WebServiceAddress = "http://www.omdbapi.com/?t=";

        public static async Task<Movie> GetMovieByTitle(string title)
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