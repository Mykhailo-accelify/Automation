using API.Profiles;
using API.Startup.Extensions;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson();

builder.Logging.ClearProviders();
builder.Logging.AddEventLog();// settings => settings.SourceName = "Automation");
//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

builder.Services.AddAutoMapper(typeof(AutomationProfile).Assembly);//Assembly.GetExecutingAssembly());

builder.Services.AddDbContext<Context>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("AutomatizationAPI")));

builder.Services.AddApplicationServices();
builder.Services.AddComparers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddApplicationAuthentication();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
if (app.Environment.IsDevelopment())
{

    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<Context>();
    context.Database.EnsureCreated();
    services.GetRequiredService<ILogger<Context>>().LogInformation("Database successful syncronize");
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();