﻿using AutoMapper;
using FootBallers.Data;
using FootBallers.Entities;
using FootBallers.Models;

namespace FootBallers.Helpers
{
    public class AutoMappingProfile : Profile
    {
        private readonly DataContext dataContext;

        public AutoMappingProfile(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public AutoMappingProfile()
        {
            CreateMap<Footballer, FootballerDto>()
                .ForMember(dest => dest.Birthday, opt => opt.ConvertUsing<DateConverter, DateTime>())
                .ForMember(dest => dest.Country, opt => opt.ConvertUsing<CountryConverter, Country>());
            CreateMap<FootballerDto, Footballer>()
                .ForMember(dest => dest.Birthday, opt => opt.ConvertUsing<DateConverter, DateOnly>())
                .ForMember(dest => dest.Country, opt => opt.ConvertUsing<CountryConverter, string>());
        }
    }

    public class DateConverter 
        : IValueConverter<DateTime, DateOnly>, IValueConverter<DateOnly, DateTime>
    {
        private readonly DataContext dataContext;

        public DateConverter(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public DateOnly Convert(DateTime sourceMember, ResolutionContext context)
            => DateOnly.FromDateTime(sourceMember);

        public DateTime Convert(DateOnly sourceMember, ResolutionContext context)
            => sourceMember.ToDateTime(new TimeOnly());
    }

    public class CountryConverter 
        : IValueConverter<string, Country>, IValueConverter<Country, string>
    {
        private DataContext dataContext;

        public CountryConverter(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public Country Convert(string sourceMember, ResolutionContext context)
            => dataContext.Countries.FirstOrDefault(e => e.Name == sourceMember);

        public string Convert(Country sourceMember, ResolutionContext context)
            => sourceMember.Name;
    }
}
