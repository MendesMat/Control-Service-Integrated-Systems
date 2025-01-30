using FluentValidation;
using Mendes.ControlService.ManagementAPI.Config;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Middlewares;
using Mendes.ControlService.ManagementAPI.Models.Customers;
using Mendes.ControlService.ManagementAPI.Repositories;
using Mendes.ControlService.ManagementAPI.Services;
using Mendes.ControlService.ManagementAPI.Validations;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container utilizando as configurações da pasta Config
builder.Services.AddControllers();

// Configuração do banco de dados
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configuração do AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configuração do Swagger
builder.Services.AddSwaggerConfiguration();

// Adiciona repositórios e serviços
builder.Services.AddScoped(typeof(ICustomerService<,,,>), typeof(CustomerService<,,,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(CustomersRepository<>));
builder.Services.AddScoped<IValidator<IndividualCustomer>, IndividualCustomerValidator>();
builder.Services.AddScoped<IValidator<CompanyCustomer>, CompanyCustomerValidator>();

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
