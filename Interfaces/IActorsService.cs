using CinemaTicketManagementSystem.Interfaces.Base;
using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IActorsService : IBaseCrud<Actor>
    {
        public Task<List<Actor>> GetAll(string name , string country);
    }
}
