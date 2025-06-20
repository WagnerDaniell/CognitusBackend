using Microsoft.EntityFrameworkCore;
using CognitusBackend.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CognitusBackend.Application.Services;
using CognitusBackend.Api.Middleware;
using CognitusBackend.Domain.Repositories;
using CognitusBackend.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<Context>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("ConnectionDataBase")
    , b => b.MigrationsAssembly("CognitusBackend.Api")));

builder.Services.AddScoped<TokenService>();
builder.Services.AddHttpClient<OpenRouterService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ISearchRepository, SearchRepository>();

builder.Services.AddCors(opcoes =>
{
    opcoes.AddPolicy("Permission", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var _secretKey = builder.Configuration["Jwt:SecretKey"]!;

var key = Encoding.ASCII.GetBytes(_secretKey);

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

//No momento utilizando http para fazer o deploy no docker
builder.WebHost.UseUrls("http://*:5000");

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("Permission");

app.UseAuthentication();
app.UseAuthorization();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
