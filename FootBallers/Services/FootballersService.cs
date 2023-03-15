using System.Runtime.InteropServices;
using AutoMapper;
using FootBallers.Data;
using FootBallers.Entities;
using FootBallers.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

        public async Task AddAsync(FootballerDto footballerAddDto)
        {
            var footballer = mapper.Map<Footballer>(footballerAddDto);
            footballer.Id = new Guid();
            await dataContext.AddAsync(footballer);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<FootballerDto>> GetAllAsync()
        {
            return mapper.Map<List<FootballerDto>>(await dataContext.Footballers.Include(e => e.Country).ToListAsync());
        }

        public async Task PutAsync(FootballerDto patchedFootballer)
        {
            var curFootballer = await dataContext.Footballers
                .Include(e => e.Country)
                .FirstOrDefaultAsync(e => e.Id == patchedFootballer.Id);
            var newFootballer = mapper.Map<Footballer>(patchedFootballer);
            await dataContext.UpdateAndSaveAsync<Footballer>(curFootballer, newFootballer);
        }
    }
}