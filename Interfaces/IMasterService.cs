using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IMasterService
    {
        public Task<List<Cinema>> GetAllCinemasAsync();
        public Task<List<Producer>> GetAllProducersAsync();
    }
}
