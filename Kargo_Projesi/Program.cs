﻿using Autofac;
using Autofac.Extensions.DependencyInjection;
using Core.Utilities.Security.Encription;
using Core.Utilities.Security.Jwt;
using Data.Abstract;
using Data.Concrete;
using Data.Concrete.EfCore.Context;
using Entity.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using NLog;
using Services.Abstract;
using Services.Concrete;
using Services.DependepcyResolvers.AutoFac;
using System;
using WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/NLog.config")); //log ayarlamaası

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var test = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ContextKargo>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()) //autofac yapılanması
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutoFacBusinessModule());
    });


builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); //auto mapper configurasyonu

builder.Services.AddIdentity<User, Role>(opt =>//Identity Ayarlaması
{
    opt.Password.RequiredLength = 6;
}).AddEntityFrameworkStores<ContextKargo>().AddDefaultTokenProviders();
builder.Services.AddAuthentication();
//IOC
//builder.Services.ConfigureServiceRegister();
//builder.Services.ConfigureLoggerService();
//builder.Services.ConfigureContextKargo();
builder.Services.AddSingleton<IAuthorizationMiddlewareResultHandler, CustomAuthorizationMiddlewareResultHandler>();

IConfiguration configuration = builder.Configuration;

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder.WithOrigins("https://localhost:7200"));
});

var tokenOptions = configuration.GetSection("TokenOptions").Get<Core.Utilities.Security.Jwt.TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidIssuer = tokenOptions.Issuer,
        ValidAudience = tokenOptions.Audience,
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
    };
});

var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);
app.ConfigureExceptionHandler2(logger);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "V1");
    });
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseCors(builder => builder.WithOrigins("https://localhost:7200").AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
public partial class Program { }