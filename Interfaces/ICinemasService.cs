using CinemaTicketManagementSystem.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces
{
    public interface ICinemasService
    {
        public Task<string> Add(Cinema model);
        public Task<string> Update(Cinema model);
        public Task<string> Delete(int Id);
        public Task<Cinema> GetById(int Id);
        public Task<List<Cinema>> GetAll(string name);
    }
}
