
using ArgonDashboard.Core.Data;
using ArgonDashboard.Core.Data.Entities;
using ArgonDashboard.Core.ExceptionHandler;
using ArgonDashboard.Core.Patterns.Repositroy;
using ArgonDashboard.Core.SwaggerAuth;
using ArgonDashboard.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using System.Reflection;
using ArgonDashboard.Core.Data.Repositories.Contracts;
using ArgonDashboard.Core.Data.Repositories;
using NuGet.Protocol.Core.Types;
using System.Text.RegularExpressions;

const string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

var migrationsAssembly = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

// Add services to the container.
var services = builder.Services;
var Configuration = builder.Configuration;

var mySqliteConnectionString = Configuration.GetConnectionString("SqLiteDatabase");

services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                        builder =>
                        {
                            builder
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                        });
});

services
    .AddRouting(options => options.LowercaseUrls = true)
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var problems = new APIBadRequestResponse(context);

            return new BadRequestObjectResult(problems);
        };
    })
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Ignore;
        options.SerializerSettings.ContractResolver = new DefaultContractResolver
        {
            NamingStrategy = new SnakeCaseNamingStrategy()
        };
    });

// Adding Authentication  
services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer  
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = Configuration["JWT:ValidAudience"],
        ValidIssuer = Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Secret"]))
    };
});

services.AddSwaggerGen(options =>
{
    options.CustomSchemaIds(type => type.ToString().Replace("ArgonDashboard.API.Models.", "").Replace("ArgonDashboard.Core.Data.Entities.", ""));

    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Argon-Dashboard APIs",
        Description = "Argon-Dashboard APIs"
    });

    options.OperationFilter<SwaggerFileOperationFilter>();

    // To Enable authorization using Swagger (JWT)    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.OAuth2,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
        Flows = new OpenApiOAuthFlows
        {
            Password = new OpenApiOAuthFlow
            {
                TokenUrl = new Uri("/api/auth/loginforswagger", UriKind.Relative)
            }
        }
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
    options.EnableAnnotations();
});

services.AddSwaggerGenNewtonsoftSupport();

services.AddDbContext<ArgonDbContext>(options =>
    options.UseSqlite(mySqliteConnectionString)
);

services.AddDefaultIdentity<User>(options =>
{
    options.User.RequireUniqueEmail = true;
    //options.Password.RequireDigit = false;
    //options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    //options.Password.RequireUppercase = false;
    //options.Password.RequireLowercase = false;
})
.AddRoles<Role>()
.AddEntityFrameworkStores<ArgonDbContext>();

services.AddTransient(s => s.GetService<IHttpContextAccessor>().HttpContext.User);

services.AddScoped<IUserRepository, UserRepository>();

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
    options.SwaggerEndpoint("/api/swagger/v1/swagger.json", "Argon-Dashboard API V1");
    options.RoutePrefix = "api/swagger";
    options.OAuthClientId("d42342rcf453242fd");
    options.OAuthClientSecret("d42342rcf453242fd");
    options.DisplayRequestDuration();
});

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();