using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GlobalCustomersController
    <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> : ControllerBase
    where TCustomer : CustomerBase
{
    private readonly ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> _customerService;

    public GlobalCustomersController(ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            TReadDto customer = _customerService.Get(id);
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