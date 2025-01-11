using AutoMapper;
using Mendes.ControlService.ManagementAPI.Data.Context;
using Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mendes.ControlService.ManagementAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IndividualCustomersController : ControllerBase
{
    private ManagementContext _context;
    private DbSet<IndividualCustomer> individualCustomersDb => _context.IndividualCustomers;
    private IMapper _mapper;

    public IndividualCustomersController(ManagementContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult Post([FromBody] CreateIndividualCustomerDto dto)
    {
        IndividualCustomer customer = _mapper.Map<IndividualCustomer>(dto);
        individualCustomersDb.Add(customer);
        _context.SaveChanges();
        return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        IndividualCustomer? customer = individualCustomersDb.FirstOrDefault(customer => customer.Id == id);

        if(customer == null) return NotFound();

        ReadIndividualCustomerDto dto = _mapper.Map<ReadIndividualCustomerDto>(customer);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateIndividualCustomerDto dto)
    {
        IndividualCustomer? customer = individualCustomersDb.FirstOrDefault(customer => customer.Id == id);

        if(customer == null) return NotFound();

        _mapper.Map(dto, customer);
        _context.SaveChanges();

        ReadIndividualCustomerDto responseDto = _mapper.Map<ReadIndividualCustomerDto>(customer);
        return Ok(responseDto);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        IndividualCustomer? customer = individualCustomersDb.FirstOrDefault(customer => customer.Id == id);

        if(customer == null) return NotFound();

        // Este Dto sera usado apenas para sistema de log de auditoria, no futuro, uma vez que nao se faz necessario no momento.
        DeleteIndividualCustomerDto dto = _mapper.Map<DeleteIndividualCustomerDto>(customer);
        individualCustomersDb.Remove(customer);
        _context.SaveChanges();
        return NoContent();
    }
}
