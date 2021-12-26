using CinemaTicketManagementSystem.Interfaces.Base;
using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface ICinemasService : IBaseCrud<Cinema>
    {
        public Task<List<Cinema>> GetAll(string name);
    }
}
