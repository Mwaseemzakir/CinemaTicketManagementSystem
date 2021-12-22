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
    public class ProducersService : IProducersService
    {
        private readonly CinemaTicketDbContext _context;
        public ProducersService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public Task<string> Add(Producer model)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Delete(Producer model)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Producer>> GetAll(string name)
        {
            try
            {
                var items = _context.Producers.AsQueryable();
                if (!String.IsNullOrEmpty(name))
                {
                    items = items.Where(x => x.FullName.ToLower().Contains(name.ToLower()));
                }

                if (items.Any())
                {
                    var List = await items.ToListAsync();
                    return List;
                }
                return new List<Producer>();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Producer> GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> Update(Producer model)
        {
            throw new System.NotImplementedException();
        }
    }
}
