using Mendes.ControlService.ManagementAPI.Config;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Repositories;
using Mendes.ControlService.ManagementAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao container utilizando as configura��es da pasta Config
builder.Services.AddControllers();

// Configura��o do banco de dados
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configura��o do AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configura��o do Swagger
builder.Services.AddSwaggerConfiguration();

// Adiciona reposit�rios e servi�os
builder.Services.AddScoped(typeof(ICustomerService<,,,>), typeof(CustomerService<,,,>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(CustomersRepository<>));

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
