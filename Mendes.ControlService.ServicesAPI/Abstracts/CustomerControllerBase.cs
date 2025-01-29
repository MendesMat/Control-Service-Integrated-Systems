using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Abstracts;

public abstract class CustomerControllerBase
    <TCustomer, TCreateDto, TReadDto, TUpdateDto> : ControllerBase
    where TReadDto : ReadCustomerDto
{
    private readonly ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto> _customerService;

    protected CustomerControllerBase(ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto> customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public virtual IActionResult Post([FromBody] TCreateDto dto)
    {
        var customer = _customerService.Post(dto);
        return CreatedAtAction(nameof(Put), new { id = customer.Id }, customer);
    }

    [HttpPut("{id}")]
    public virtual IActionResult Put(int id, [FromBody] TUpdateDto dto)
    {
        try
        {
            var customer = _customerService.Put(id, dto);
            return Ok(customer);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
