using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;
using Mendes.ControlService.ManagementAPI.Interfaces;
using Mendes.ControlService.ManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Controllers.Proposals;

/// <summary>
/// Controlador para gerenciar propostas.
/// Este controlador oferece operações para consultar, listar, criar, atualizar e excluir propostas.
/// </summary>

[ApiController]
[Route("management/[controller]")]
public class ProposalController : ControllerBase
{
    private readonly IService
        <Proposal, CreateProposalDto, ReadProposalDto, UpdateProposalDto> _proposalService;

    public ProposalController(IService
        <Proposal, CreateProposalDto, ReadProposalDto, UpdateProposalDto> proposalService)
    {
        _proposalService = proposalService;
    }

    /// <summary>
    /// Cria uma nova proposta.
    /// </summary>
    /// <param name="dto">DTO contendo os dados da proposta a ser criada.</param>
    /// <returns>Retorna um status 201 Created com a localização do novo recurso.</returns>
    /// <example>
    /// {
    ///   "customerId": 1,
    ///   "amount": 1500.00,
    ///   "dueDate": "2025-12-31"
    /// }
    /// </example>
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult Post([FromBody] CreateProposalDto dto)
    {
        try
        {
            var proposal = _proposalService.Post(dto);
            return CreatedAtAction(nameof(Get), new { id = proposal.Id }, proposal);
        }
        catch (ValidationException ex)
        {
            return BadRequest(new { message = "Erro de validação", errors = ex.Message });
        }
    }

    /// <summary>
    /// Obtém uma proposta pelo seu identificador único.
    /// </summary>
    /// <param name="id">Identificador da proposta.</param>
    /// <returns>Retorna a proposta com o ID fornecido.</returns>
    /// <response code="200">Proposta encontrada e retornada com sucesso.</response>
    /// <response code="404">Proposta não encontrada.</response>
    
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var proposal = _proposalService.Get(id);
            return Ok(proposal);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Obtém todos as propostas cadastradas.
    /// </summary>
    /// <returns>Retorna a lista de todos as propostas.</returns>
    /// <response code="200">Lista de clientes retornada com sucesso.</response>
    /// <response code="500">Erro interno do servidor.</response>

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var proposals = _proposalService.GetAll();
            return Ok(proposals);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

        /// <summary>
        /// Atualiza uma proposta existente.
        /// </summary>
        /// <param name="id">Identificador da proposta a ser atualizada.</param>
        /// <param name="dto">DTO contendo os novos dados da proposta.</param>
        /// <returns>
        /// Retorna 200 OK se a atualização for bem-sucedida.
        /// Retorna 404 Not Found se a proposta não for encontrada.
        /// Retorna 400 BadRequest em caso de dados inválidos.
        /// </returns>

        [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UpdateProposalDto dto)
    {
        try
        {
            var proposal = _proposalService.Put(id, dto);
            return Ok(proposal);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Exclui uma proposta baseado no seu identificador.
    /// </summary>
    /// <param name="id">Identificador da proposta a ser excluída.</param>
    /// <returns>Retorna um código 204 No Content se a exclusão for bem-sucedida.</returns>
    /// <response code="204">Proposta excluída com sucesso.</response>
    /// <response code="404">Proposta não encontrada.</response>
    
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _proposalService.Delete(id);
            return NoContent();
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }
}