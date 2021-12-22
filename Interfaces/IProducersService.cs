using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface IProducersService
    {
        public Task<string> Add(Producer model);
        public Task<string> Update(Producer model);
        public Task<string> Delete(Producer model);
        public Task<Producer> GetById(int Id);
        public Task<List<Producer>> GetAll(string name);
    }
}
