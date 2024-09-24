var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

const string policyName = "CorsPolicy";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseCors(policyName);
app.UseAuthorization();

app.MapControllers();

app.Run();
