using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

/// <summary>
/// DTO (Data Transfer Object) para atualiza��o de dados de uma proposta.
/// Cont�m as propriedades necess�rias para atualizar as informa��es de uma proposta.
/// </summary>

public class UpdateProposalDto
{
    public int? PayingEntityId { get; set; }

    [Required]
    public decimal Value { get; set; }
}