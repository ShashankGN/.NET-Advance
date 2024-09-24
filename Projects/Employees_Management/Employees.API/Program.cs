using Employees.API.Authetication;
using Employees.API.Contracts;
using Employees.API.DBContext;
using Employees.API.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(jwtOption =>
{
    var key = builder.Configuration.GetValue<string>("JwtConfig:Key");
    var keyBytes = Encoding.ASCII.GetBytes(key);
    jwtOption.SaveToken = true;
    jwtOption.TokenValidationParameters = new TokenValidationParameters
    {

        ValidAudience = "http://localhost:5269",
        ValidIssuer = "http://localhost:5269",
        IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
        ValidateLifetime = true,
        ValidateAudience = true,
        ValidateIssuer = true
    };
});

builder.Services.AddScoped<IJwtTokenManager,JwtTokenManager >();
builder.Services.AddScoped<IEmployee,EmployeeInMemoryRepository>();
//builder.Services.AddDbContext<EmployeeDBContext>(options =>
//{
//    options.UseInMemoryDatabase("EmployeeDB");
//})
builder.Services.AddDbContext<EmployeeDBContext>(options =>
{
    //Testing
    var connectionstring = builder.Configuration.GetConnectionString("EmployeeDBConnection");
    options.UseSqlServer(connectionstring);

});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
                        
app.Run();

