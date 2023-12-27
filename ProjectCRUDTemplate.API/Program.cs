using Microsoft.EntityFrameworkCore;
using ProjectCRUDTemplate.Core.Entity;
using ProjectCRUDTemplate.Infrustructure.Data;
using System.Reflection;
using ProjectCRUDTemplate.Application;


var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddTransient<IBaseRepository<Project>, BaseRepository<Project>>();
builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

var configuration = builder.Configuration;
string connectionString = configuration.GetConnectionString("YourDbConnection");
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.LoadApplicationDependencies();

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