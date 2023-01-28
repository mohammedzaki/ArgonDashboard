
using ArgonDashboard.Core.Data;
using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Core.ExceptionHandler;
using ArgonDashboard.Core.Patterns.Repositroy;
using ArgonDashboard.Core.SwaggerAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var Configuration = builder.Configuration;

var mySqliteConnectionString = Configuration.GetConnectionString("SqLiteDatabase");

services.AddDbContext<ArgonDbContext>(options =>
    options.UseSqlite(mySqliteConnectionString)
);

services.AddControllersWithViews();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

services.AddScoped<IRepository<Department, long>, EntityRepository<ArgonDbContext, Department, long>>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
}

app.UseArgonCoreAPIExceptionMiddleware();

app.UseSwaggerAuthorized();

app.UseSwagger(options => {
    options.RouteTemplate = "api/swagger/{documentname}/swagger.json";
});

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "ArgonDashboard API V1");
    options.RoutePrefix = "api/swagger";
    options.OAuthClientId("d42342rcf453242fd");
    options.OAuthClientSecret("d42342rcf453242fd");
    options.DisplayRequestDuration();
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();