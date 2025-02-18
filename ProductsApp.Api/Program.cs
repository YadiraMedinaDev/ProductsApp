using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Api.Filters;
using ProductsApp.Infrastructure.DataSource;
using ProductsApp.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
var assemblyApplication = Assembly.Load("ProductsApp.Application");

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ExceptionFilters>();
});


builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("database"));
});

builder.Services.AddAutoMapper(assemblyApplication);

builder.Services.AddServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(configuration => configuration.RegisterServicesFromAssemblies(assemblyApplication));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
