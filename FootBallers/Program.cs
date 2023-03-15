using FootBallers.Data;
using FootBallers.Entities;
using FootBallers.Models;
using FootBallers.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IFootballersService, FootballersService>();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<Footballer, FootballerDto>()
        .ForMember(dest => dest.Birthday, opt => 
            opt.MapFrom(src => new DateOnly(src.Birthday.Year, src.Birthday.Month, src.Birthday.Day)))
        .ForMember(dest => dest.Country, opt =>
            opt.MapFrom(src => src.Country.Name));
    cfg.CreateMap<FootballerDto, Footballer>()
        .ForMember(dest => dest.Birthday, opt =>
            opt.MapFrom(src => src.Birthday.ToDateTime(new TimeOnly())))
        .ForMember(dest => dest.Country, opt =>
            opt.MapFrom(src => new Country{Id=new Guid(), Name = "Россия"}));
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
