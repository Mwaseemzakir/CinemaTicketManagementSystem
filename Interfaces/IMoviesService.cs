using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IMoviesService
    {
        public  Task<string> Add(Movie model);
        public  Task<string> Update(Movie model);
        public  Task<string> Delete(int Id);
        public  Task<Movie> GetById(int Id);
        public  Task<List<Movie>> GetAll(string name);
    }
}
