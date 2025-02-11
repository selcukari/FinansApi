using Business.Abstract;
using Business.Abstract.Cache;
using Business.Abstract.Dapper;
using Business.Concrete;
using Business.Concrete.Cache;
using Business.Concrete.Dapper;
using DataAccess.Abstract;
using DataAccess.Abstract.Dapper;
using DataAccess.Concrete.Dapper;
using DataAccess.Concrete.EntityFreamwork;
using DataAccess.Concrete.EntityFreamwork.Contexts;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

// Dapper mapping ayarý
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IBaseDp<FinancialAsset>, BaseDp<FinancialAsset>>();
builder.Services.AddScoped<IDpFinancialService, DpFinancialManager>();
builder.Services.AddScoped<IDpFinancialDal, DpFinancialDal>();

builder.Services.AddScoped<IFinancialService, FinancialManager>();
builder.Services.AddScoped<IFinancialDal, EFFinancialDal>();

// cache
// builder.Services.AddScoped<ICacheService, RedisCacheService>();
//builder.Services.AddScoped<ICacheService>(provider =>
//    new RedisCacheService("localhost:6379"));
builder.Services.AddScoped<ICacheService, MemCacheService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<FinancialDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
