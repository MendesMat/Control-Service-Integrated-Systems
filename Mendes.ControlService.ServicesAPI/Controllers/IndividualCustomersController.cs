﻿using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[ApiController]
[Route("managementApi/[controller]")]
public class IndividualCustomersController : CustomerControllerBase
    <IndividualCustomer,
    CreateCustomerDto,
    ReadCustomerDto,
    UpdateCustomerDto>
{
    public IndividualCustomersController(ICustomerService
        <IndividualCustomer, 
        CreateCustomerDto, 
        ReadCustomerDto, 
        UpdateCustomerDto> 
        customerService) 
        : base(customerService)
    { }
}
