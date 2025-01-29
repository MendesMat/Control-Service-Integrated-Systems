using Mendes.ControlService.ManagementAPI.Abstracts;
using System.Text.Json.Serialization;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos;

public class CreateCustomerDto : CustomerDtoBase
{
    // IndividualCustomer Properties
    public string? Cpf { get; set; }

    // CompanyCustomer Properties
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}
