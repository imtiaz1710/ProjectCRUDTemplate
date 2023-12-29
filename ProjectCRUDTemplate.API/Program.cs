
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

builder.Services.AddTransient<IBaseRepository<Project>, BaseRepository<Project>>();

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();

var configuration = builder.Configuration;

string connectionString = configuration.GetConnectionString("DbConnection");
builder.Services.AddDbContext<ProjectDbContext>(options =>
    options.UseSqlServer(connectionString));

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
