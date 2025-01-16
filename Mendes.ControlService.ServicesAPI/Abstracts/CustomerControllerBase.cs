using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Abstracts;

public abstract class CustomerControllerBase
    <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> : ControllerBase
    where TCustomer : CustomerBase
    where TReadDto : CustomerDtoBase
{
    private readonly ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> _customerService;

    protected CustomerControllerBase(ICustomerService
        <TCustomer, TCreateDto, TReadDto, TUpdateDto, TDeleteDto> customerService)
    {
        _customerService = customerService;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public virtual IActionResult Post([FromBody] TCreateDto dto)
    {
        var result = _customerService.Post(dto);
        return CreatedAtAction(nameof(Post), new { id = result.Id }, result);
    }

    [HttpPut("{id}")]
    public virtual IActionResult Put(int id, [FromBody] TUpdateDto dto)
    {
        try
        {
            var result = _customerService.Put(id, dto);
            return Ok(result);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
