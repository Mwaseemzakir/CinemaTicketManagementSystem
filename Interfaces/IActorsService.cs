using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IActorsService
    {
        public Task<string> Add(Actor model);
        public Task<string> Update(Actor model);
        public Task<string> Delete(int Id);
        public Task<Actor> GetById(int Id);
        public Task<List<Actor>> GetAll(string name , string country);
    }
}
