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
    public class ActorsService : IActorsService
    {

        private readonly CinemaTicketDbContext _context;
        public ActorsService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public Task<string> Add(Actor model)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(Actor model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Actor>> GetAll(string name, string country)
        {
            try
            {
                var items = _context.Actors.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.FullName.ToLower().Contains(name.ToLower()));
                }
                if (!String.IsNullOrEmpty(country))
                {
                    items = items.Where(x => x.Country.ToLower().Contains(country.ToLower()));
                }
                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Actor>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Actor> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(Actor model)
        {
            throw new System.NotImplementedException();
        }
    }
}
