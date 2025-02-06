using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFreamwork;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFinancialService, FinancialManager>();
builder.Services.AddScoped<IFinancialDal, EFFinancialDal>();

builder.Services.AddControllers();

var deneme = builder.Configuration.GetSection("ConnectionStrings");
var deneme1 = builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
