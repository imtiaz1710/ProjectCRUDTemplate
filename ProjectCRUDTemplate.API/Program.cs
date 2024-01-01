
using ProjectCRUDTemplate.Core.Interfaces;
using ProjectCRUDTemplate.Infrustructure.Data.DbContexts;
using ProjectCRUDTemplate.Infrustructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
           .WriteTo.Console()
           .CreateLogger();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

builder.Services.AddTransient<IProjectCommandRepository, ProjectCommandRepository>();

builder.Services.AddScoped<IProjectQueryRepository, ProjectQueryRepository>();

var configuration = builder.Configuration;

string connectionString = configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<ProjectCommandDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddSingleton<ProjectQueryDbContext>();

builder.Services.LoadApplicationDependencies();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));



var app = builder.Build();

//Add support to logging request with SERILOG
app.UseSerilogRequestLogging();

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
