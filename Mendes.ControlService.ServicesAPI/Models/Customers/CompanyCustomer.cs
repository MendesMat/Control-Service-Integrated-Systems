using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Models.Customers;

/// <summary>
/// Representa um cliente do tipo empresa.
/// Herda as propriedades de <see cref="CustomerBase"/> e adiciona informações específicas de empresas.
/// </summary>

public class CompanyCustomer : CustomerBase
{
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}
