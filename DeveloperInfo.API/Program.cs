using DeveloperInfo.Infrastructure;
using DeveloperInfo.Infrastructure.DataAccess;
using DeveloperInfo.ServiceImplementations;
using DeveloperInfo.ServiceContracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DevelopersContext>(opt =>
{
    opt.UseNpgsql(config.GetConnectionString("MainDb"));
});
builder.Services.AddScoped<DbContext, DevelopersContext>();
builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
builder.Services.AddTransient<IDeveloperService, DeveloperService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
