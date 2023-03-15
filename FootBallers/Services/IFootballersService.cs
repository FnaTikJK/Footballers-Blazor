using FootBallers.Entities;
using FootBallers.Models;

namespace FootBallers.Services
{
    public interface IFootballersService
    {
        public Task AddAsync(FootballerDto footballerAdd);
        public Task<List<FootballerDto>> GetAllAsync();
        public Task PutAsync(FootballerDto patchedFootballer);
        public Task<List<string>> GetCountryNames();
        public Task<List<string>> GetTeamNames();
        public Task<List<string>> GetSexNames();
    }
}
