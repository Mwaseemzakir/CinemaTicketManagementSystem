using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using CinemaTicketManagementSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Utils.Helpers
{
    public static class Helpers
    {
        public static string AddFile(string fileName)
        {
            

            string imagesFolderPath = "Files/Images";

            //If Folder does not exists then create it
            if (!File.Exists(imagesFolderPath))
            {
                Directory.CreateDirectory(imagesFolderPath);
            }

            // To avoid files name replication I have used GUID
            string imageUrl = Guid.NewGuid().ToString() + Path.GetExtension(fileName);

            //Below two lines are responsible to copy image in our images folder
            byte[] imageBytes = Convert.FromBase64String(fileName);
            File.WriteAllBytes(imagesFolderPath, imageBytes);
            return imageUrl;



        }
        public static void RemoveFile(string fileName)
        {

        }
        public static string ConvertListToCommaSeperatedString(List<string> list)
        {
            if(list.Any() && list.Count > 0)
            {
                return String.Join(",", list);
            }
            return "";
            
        }
        public static MovieVM ConvertMovieToMovieVM(Movie movie)
        {
            var movieVM = new MovieVM
            {
                ActorIds = movie.ActorsMovies.Select(x => x.ActorId).ToList(),
                CinemaId = movie.CinemaId,
                Description = movie.Description,
                EndDate = movie.EndDate,
                Id = movie.Id,
                ImageURL = movie.ImageURL,
                MovieCategory = movie.MovieCategory,
                Name = movie.Name,
                Price = movie.Price,
                ProducerId = movie.ProducerId,
                StartDate = movie.StartDate,
            };
            return movieVM;
        }

        public static Movie ConvertMovieVMToMovie(MovieVM movieVm)
        {
           
            List<Actors_Movies> acmList = new List<Actors_Movies>();
            if(movieVm.ActorIds.Any() && movieVm.ActorIds.Count() > 0)
            {
                foreach (var actorId in movieVm.ActorIds)
                {
                    acmList.Add(new Actors_Movies
                    {
                        ActorId = actorId,
                        MovieId = movieVm.Id
                    });
                }
            }
            var movie = new Movie
            {
                CinemaId = movieVm.CinemaId,
                Description = movieVm.Description,
                EndDate = movieVm.EndDate,
                Id = movieVm.Id,
                ImageURL = movieVm.ImageURL,
                MovieCategory = movieVm.MovieCategory,
                Name = movieVm.Name,
                Price = movieVm.Price,
                ProducerId = movieVm.ProducerId,
                StartDate = movieVm.StartDate,
                ActorsMovies = acmList
            };
            return movie;
        }


    }
}
