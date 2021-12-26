using CinemaTicketManagementSystem.Interfaces.Base;
using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IProducersService : IBaseCrud<Producer>
    {
        public Task<List<Producer>> GetAll(string name);
    }
}
