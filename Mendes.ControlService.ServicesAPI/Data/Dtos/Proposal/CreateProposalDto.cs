using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

/// <summary>
/// DTO (Data Transfer Object) para criação de uma proposta.
/// Contém as propriedades necessárias para criar uma proposta.
/// </summary>

public class CreateProposalDto
{
    [Required]
    public int CustomerId { get; set; }

    public int? PayingEntityId { get; set; }

    [Required]
    public decimal Value { get; set; }
}
