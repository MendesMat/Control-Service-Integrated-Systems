using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : CustomerControllerBase
    <IndividualCustomer,
    CreateIndividualCustomerDto,
    ReadCustomerDto,
    UpdateIndividualCustomerDto,
    DeleteCustomerDto>
{
    public IndividualCustomersController(ICustomerService
        <IndividualCustomer, 
        CreateIndividualCustomerDto, 
        ReadCustomerDto, 
        UpdateIndividualCustomerDto, 
        DeleteCustomerDto> 
        customerService) 
        : base(customerService)
    {
    }
}
