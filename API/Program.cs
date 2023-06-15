using Application.UseCases;
using Application.UseCases.Interfaces;
using Domain.Repositories;
using Infra;
using Infra.Configs;
using Infra.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConeection");
builder.Services.AddDbContext<ApiDbContext>(
        options => options.UseNpgsql(conn)
);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = true;
    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtEnv.JWT_SECURITY_KEY)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

#region DependencyInjection
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IAuthUseCases, AuthUseCases>();
#endregion DependencyInjection

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseReDoc(c =>
    {
        c.DocumentTitle = "REDOC API Documentation";
        c.SpecUrl = "/swagger/v1/swagger.json";
    });
}



app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
