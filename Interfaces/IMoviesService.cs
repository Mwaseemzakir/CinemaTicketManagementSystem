using CinemaTicketManagementSystem.Interfaces.Base;
using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IMoviesService : IBaseCrud<Movie>
    {
        public  Task<List<Movie>> GetAll(string name);
    }
}
