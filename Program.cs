using Microsoft.EntityFrameworkCore;
using Service_PhongTro.Models;
using Service_PhongTro.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDBContext>(option => 
          option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<DayTroService>();
builder.Services.AddTransient<DichVuService>();
builder.Services.AddTransient<DichVuSuDungService>();
builder.Services.AddTransient<DienNuocService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
