using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Customer;

/// <summary>
/// DTO (Data Transfer Object) para criação de um cliente.
/// Contém as propriedades necessárias para criar um cliente individual ou de empresa.
/// </summary>

public class CreateCustomerDto : CustomerDtoBase
{
    // IndividualCustomer Properties
    public string? Cpf { get; set; }

    // CompanyCustomer Properties
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}
