using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[ApiController]
[Route("management/[controller]")]
public class AllCustomersController : ControllerBase
{
    private readonly ICustomerService
        <CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto> _customerService;

    public AllCustomersController(ICustomerService
        <CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto> customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var customer = _customerService.Get(id);
            return Ok(customer);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var customers = _customerService.GetAll();
            return Ok(customers);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _customerService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}
