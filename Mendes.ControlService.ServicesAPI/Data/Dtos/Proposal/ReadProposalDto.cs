namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

/// <summary>
/// DTO (Data Transfer Object) para leitura de dados de uma proposta.
/// Cont�m as propriedades necess�rias para exibir as informa��es de uma proposta.
/// </summary>

public class ReadProposalDto
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public int? PayingEntityId { get; set; }
    public string? PayingEntityName { get; set; }
    public decimal Value { get; set; }
}
