using CinemaTicketManagementSystem.Database;
using CinemaTicketManagementSystem.Interfaces;
using CinemaTicketManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Services
{
    public class MasterService : IMasterService
    {
        private readonly CinemaTicketDbContext _context;
        public MasterService(CinemaTicketDbContext context)
        {
            _context = context;
        }
        public async Task<List<Cinema>> GetAllCinemasAsync() => await _context.Cinemas.ToListAsync();
        public async Task<List<Producer>> GetAllProducersAsync() => await _context.Producers.ToListAsync();
        public async Task<List<Actor>> GetAllActorsAsync() => await _context.Actors.ToListAsync();

    }
}
