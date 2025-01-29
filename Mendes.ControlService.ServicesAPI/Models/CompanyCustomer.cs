using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Models;

public class CompanyCustomer : CustomerBase
{
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}
