using Data.Abstract;
using Data.Concrete;
using Data.Concrete.EfCore.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NLog;
using Services.Abstract;
using Services.Concrete;
using System;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/NLog.config")); //log ayarlamaası

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextKargo>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//builder.Services.AddDbContext<ContextKargo>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});

//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //auto mapper configurasyonu

//builder.Services.AddIdentity<User, Role>(opt =>//Identity Ayarlaması
//{
//    //opt.Password.RequireDigit = true;
//    //opt.Password.RequireLowercase = false;
//    //opt.Password.RequireUppercase = false;
//    //opt.Password.RequireNonAlphanumeric = false;
//    opt.Password.RequiredLength = 6;
//}).AddEntityFrameworkStores<ContextKargo>().AddDefaultTokenProviders().AddDefaultTokenProviders();
builder.Services.AddIdentity<User, Role>().AddEntityFrameworkStores<ContextKargo>();
builder.Services.AddAuthentication();
//IOC
builder.Services.ConfigureServiceRegister();
builder.Services.ConfigureLoggerService();

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
