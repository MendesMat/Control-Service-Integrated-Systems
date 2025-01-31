using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Customer;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

/// <summary>
/// Controlador para gerenciamento de clientes de empresas.
/// Herda de CustomerControllerBase com tipos específicos para clientes de empresas.
/// </summary>

[ApiController]
[Route("managementApi/[controller]")]
public class CompanyCustomersController : CustomerControllerBase
    <CompanyCustomer,
    CreateCustomerDto,
    ReadCustomerDto,
    UpdateCustomerDto>
{
    public CompanyCustomersController(IService
        <CreateCustomerDto,
        ReadCustomerDto,
        UpdateCustomerDto>
        customerService)
        : base(customerService)
    { }
}
