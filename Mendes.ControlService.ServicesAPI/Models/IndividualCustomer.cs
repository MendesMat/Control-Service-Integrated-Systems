using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Models;

/// <summary>
/// Representa um cliente do tipo individual.
/// Herda as propriedades de <see cref="CustomerBase"/> e adiciona informações específicas de clientes individuais.
/// </summary>

public class IndividualCustomer : CustomerBase
{
    public string? Cpf { get; set; }
}
