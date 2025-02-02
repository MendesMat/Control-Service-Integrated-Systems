using FluentValidation;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Config;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Customer;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Mendes.ControlService.ManagementAPI.Repositories;
using Mendes.ControlService.ManagementAPI.Services;
using Mendes.ControlService.ManagementAPI.Utilities;
using Mendes.ControlService.ManagementAPI.Validations;

var builder = WebApplication.CreateBuilder(args);

// Adiciona os servi�os ao container utilizando as configura��es da pasta Config
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Adiciona o conversor de CustomerBase para classes concretas
        options.JsonSerializerOptions.Converters.Add(new CustomerBaseConverter());
    });

// Configura��o do banco de dados
builder.Services.AddDatabaseConfiguration(builder.Configuration);

// Configura��o do AutoMapper
builder.Services.AddAutoMapperConfiguration();

// Configura��o do Swagger
builder.Services.AddSwaggerConfiguration();

// Adiciona reposit�rios
builder.Services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));

// Adiciona os servi�os de clientes
builder.Services.AddScoped(typeof(IService<CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>),
    typeof(CustomerService<CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>));

builder.Services.AddScoped(typeof
    (IService<IndividualCustomer, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>), 
    typeof(CustomerService<IndividualCustomer, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>));

builder.Services.AddScoped(typeof
    (IService<CompanyCustomer, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>),
    typeof(CustomerService<CompanyCustomer, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto>));

// Adiciona os servi�os de propostas
builder.Services.AddScoped(typeof(
    IService<Proposal, CreateProposalDto, ReadProposalDto, UpdateProposalDto>),
    typeof(ProposalService<Proposal, CreateProposalDto, ReadProposalDto, UpdateProposalDto>));

// Adiciona os validadores de clientes
builder.Services.AddScoped<IValidator<IndividualCustomer>, IndividualCustomerValidator>();
builder.Services.AddScoped<IValidator<CompanyCustomer>, CompanyCustomerValidator>();
builder.Services.AddScoped<IValidator<Proposal>, ProposalValidator>();

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