using Mendes.ControlService.ManagementAPI.Data.Dtos;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Abstracts;

/// <summary>
/// Classe base abstrata para controladores de clientes.
/// Implementa operações comuns como criação e atualização de clientes.
/// </summary>
/// <typeparam name="TCustomer">Tipo da entidade cliente.</typeparam>
/// <typeparam name="TCreateDto">Tipo do DTO para criação de clientes.</typeparam>
/// <typeparam name="TReadDto">Tipo do DTO para leitura de clientes.</typeparam>
/// <typeparam name="TUpdateDto">Tipo do DTO para atualização de clientes.</typeparam>

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

    /// <summary>
    /// Cria um novo cliente.
    /// </summary>
    /// <param name="dto">DTO contendo os dados do cliente a ser criado.</param>
    /// <returns>Retorna um status 201 Created com a localização do novo recurso.</returns>
    /// <example>
    /// {
    ///   "name": "Cliente Exemplo",
    ///   "telephone1": "123456789",
    ///   "email": "cliente.exemplo@email.com",
    ///   "cep": "12345-678",
    ///   "address": "Rua A",
    ///   "number": 123
    /// }
    /// </example>


    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public virtual IActionResult Post([FromBody] TCreateDto dto)
    {
        try
        {
            var customer = _customerService.Post(dto);
            return CreatedAtAction(nameof(Put), new { id = customer.Id }, customer);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = "Erro de validação", errors = ex.Message });
        }      
    }

    /// <summary>
    /// Atualiza um cliente existente.
    /// </summary>
    /// <param name="id">Identificador do cliente a ser atualizado.</param>
    /// <param name="dto">DTO contendo os novos dados do cliente.</param>
    /// <returns>
    /// Retorna 200 OK se a atualização for bem-sucedida.
    /// Retorna 404 Not Found se o cliente não for encontrado.
    /// Retorna 400 BadRequest em caso de dados inválidos.
    /// </returns>


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
