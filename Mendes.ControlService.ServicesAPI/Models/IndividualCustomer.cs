using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

/// <summary>
/// Representa um cliente do tipo individual.
/// Herda as propriedades de <see cref="CustomerBase"/> e adiciona informações específicas de clientes individuais.
/// </summary>

public class IndividualCustomer : CustomerBase
{
    [StringLength(11, MinimumLength = 11)]
    public string? Cpf { get; set; }
}