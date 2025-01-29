using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[ApiController]
[Route("managementApi/[controller]")]
public class CompanyCustomersController : CustomerControllerBase
    <CompanyCustomer,
    CreateCustomerDto,
    ReadCustomerDto,
    UpdateCustomerDto>
{
    public CompanyCustomersController(ICustomerService
        <CompanyCustomer,
        CreateCustomerDto,
        ReadCustomerDto,
        UpdateCustomerDto>
        customerService)
        : base(customerService)
    { }
}
