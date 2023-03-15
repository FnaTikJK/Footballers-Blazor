using FootBallers.Entities;
using FootBallers.Models;

namespace FootBallers.Services
{
    public interface IFootballersService
    {
        public Task AddAsync(FootballerDto footballer);
        public Task<List<Footballer>> GetAllAsync();
        public Task DeleteAsync(Guid id);
    }
}
