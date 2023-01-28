using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using ArgonDashboard.Core.Data;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var Configuration = builder.Configuration;

var mySqlConnectionString = Configuration.GetConnectionString("SqLiteDatabase");

var migrationsAssembly = "ArgonDashboard.Migrations";

builder.Services.AddDbContext<ArgonDbContext>(options =>
    options.UseSqlite(mySqlConnectionString, b => b.MigrationsAssembly(migrationsAssembly))
);

var app = builder.Build();

app.Run();
