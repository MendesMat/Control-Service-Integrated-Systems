using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

/// <summary>
/// DTO (Data Transfer Object) para cria��o de uma proposta.
/// Cont�m as propriedades necess�rias para criar uma proposta.
/// </summary>

public class CreateProposalDto
{
    [Required]
    public int CustomerId { get; set; }

    public int? PayingEntityId { get; set; }

    [Required]
    public decimal Value { get; set; }
}
