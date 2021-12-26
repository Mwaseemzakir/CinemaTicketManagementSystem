using System.Threading.Tasks;

namespace CinemaTicketManagementSystem.Interfaces.Base
{
    public interface IBaseCrud<T>
    {
        public Task<string> AddAsync(T model);
        public Task<string> UpdateAsync(T model);
        public Task<string> DeleteAsync(int Id);
        public Task<T> GetByIdAsync(int Id);
    }
}
