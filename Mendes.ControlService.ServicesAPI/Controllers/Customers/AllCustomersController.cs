using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Customer;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Mendes.ControlService.ManagementAPI.Controllers.Customers;

/// <summary>
/// Controlador para gerenciar todos os tipos de clientes.
/// Este controlador oferece operações para consultar, listar e excluir clientes.
/// </summary>

[ApiController]
[Route("management/[controller]")]
public class AllCustomersController : ControllerBase
{
    private readonly IService
        <CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto> _customerService;

    public AllCustomersController(IService
        <CustomerBase, CreateCustomerDto, ReadCustomerDto, UpdateCustomerDto> customerService)
    {
        _customerService = customerService;
    }

    /// <summary>
    /// Obtém um cliente pelo seu identificador único.
    /// </summary>
    /// <param name="id">Identificador do cliente.</param>
    /// <returns>Retorna o cliente com o ID fornecido.</returns>
    /// <response code="200">Cliente encontrado e retornado com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>

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

    /// <summary>
    /// Obtém todos os clientes cadastrados.
    /// </summary>
    /// <returns>Retorna a lista de todos os clientes.</returns>
    /// <response code="200">Lista de clientes retornada com sucesso.</response>
    /// <response code="500">Erro interno do servidor.</response>

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

    /// <summary>
    /// Exclui um cliente baseado no seu identificador.
    /// </summary>
    /// <param name="id">Identificador do cliente a ser excluído.</param>
    /// <returns>Retorna um código 204 No Content se a exclusão for bem-sucedida.</returns>
    /// <response code="204">Cliente excluído com sucesso.</response>
    /// <response code="404">Cliente não encontrado.</response>

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