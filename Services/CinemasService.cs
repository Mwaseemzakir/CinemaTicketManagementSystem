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
    public class CinemasService : ICinemasService
    {
        private readonly CinemaTicketDbContext _context;
        public CinemasService(CinemaTicketDbContext context)
        {
            _context = context; 
        }
        public Task<string> Add(Cinema model)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(Cinema model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Cinema>> GetAll(string name)
        {
            try
            {
                var items = _context.Cinemas.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.Name.ToLower().Contains(name.ToLower()));
                }
              
                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Cinema>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Cinema> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(Cinema model)
        {
            throw new System.NotImplementedException();
        }
    }
}
