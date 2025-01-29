using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Profiles;
using Mendes.ControlService.ManagementAPI.Repositories;
using Mendes.ControlService.ManagementAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddDbContext<ManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


builder.Services.AddAutoMapper(typeof(CustomerProfile));

builder.Services.AddScoped(typeof(ICustomerService<,,,>), typeof(CustomerService<,,,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(CustomersRepository<>));

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Management API",
        Version = "v1",
        Description = "API para gerenciamento de clientes e serviços"
    });

    options.SchemaGeneratorOptions.SupportNonNullableReferenceTypes = true;
});

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