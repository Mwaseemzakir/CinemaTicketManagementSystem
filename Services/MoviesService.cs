using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
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
            throw new System.NotImplementedException();
        }

        public async Task<string> Delete(Movie model)
        {
            throw new System.NotImplementedException();
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Movie> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<string> Update(Movie model)
        {
            throw new System.NotImplementedException();
        }
    }
}
