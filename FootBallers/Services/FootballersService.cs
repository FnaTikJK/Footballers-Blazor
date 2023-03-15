using AutoMapper;
using FootBallers.Data;
using FootBallers.Entities;
using FootBallers.Models;
using Microsoft.EntityFrameworkCore;

namespace FootBallers.Services
{
    public class FootballersService : IFootballersService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public FootballersService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task AddAsync(FootballerDto footballerDto)
        {
            var footballer = mapper.Map<Footballer>(footballerDto);
            footballer.Id = new Guid();
            await dataContext.AddAsync(footballer);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Footballer>> GetAllAsync()
        {
            return await dataContext.Footballers.ToListAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var footballer = await dataContext.Footballers.FirstOrDefaultAsync(e => e.Id == id);
            if (footballer != null)
            {
                dataContext.Footballers.Remove(footballer);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
