using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using CinemaTicketManagementSystem.Utils.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Services
{
    public class MoviesService : IMoviesService
    {
        private readonly CinemaTicketDbContext _context;
        public MoviesService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public async Task<string> Add(Movie model)
        {
            try
            {
                if (!String.IsNullOrEmpty(model.ImageURL))
                {
                    string imageUrl = Helpers.AddFile(model.ImageURL);
                    model.ImageURL = imageUrl;
                    Helpers.AddFile(model.ImageURL);
                }
                _context.Movies.Add(model);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> Delete(int Id)
        {
            try
            {
                if (Id <= 0) return "Invalid Id";
                var movie = await _context.Movies.FindAsync(Id);
                if (movie == null) return "No record found";
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
                return "true";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Movie>> GetAll(string name)
        {
            try
            {
                var movies = _context.Movies.Include(x => x.Cinema).AsQueryable();
                if(!String.IsNullOrEmpty(name))
                {
                    movies = movies.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }
                if(movies.Any())
                {
                    var movieList = await movies.ToListAsync();
                    return movieList;
                }
                return new List<Movie>();   
                            
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Movie> GetById(int Id)
        {
            try
            {
                if (Id < 0) return new Movie();
                var item = await _context.Movies.FindAsync(Id);
                if (item == null) return new Movie();
                return item;
            }
            catch (Exception)
            {
                return new Movie();
            }
        }

        public async Task<string> Update(Movie model)
        {
            if (model == null || model.Id <= 0) return "Incomplete Information";
            var movie = await _context.Movies.FindAsync(model.Id);
            if (movie == null) return "Record does not exist";
            if (model.ImageURL != null)
            {
                //First Remove Existing File from Folder and then Add New One 
            }
            movie.CinemaId = model.CinemaId;
            movie.ProducerId = model.ProducerId;
            movie.Description = model.Description;
            movie.StartDate = model.StartDate;
            movie.EndDate = model.EndDate;
            movie.Price = model.Price;
            movie.Name = model.Name;
            await _context.SaveChangesAsync();
            return "true"; 
        }
    }
}
