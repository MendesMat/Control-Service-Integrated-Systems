using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

/// <summary>
/// DTO (Data Transfer Object) para atualização de dados de uma proposta.
/// Contém as propriedades necessárias para atualizar as informações de uma proposta.
/// </summary>

public class UpdateProposalDto
{
    public int? PayingEntityId { get; set; }

    [Required]
    public decimal Value { get; set; }
}