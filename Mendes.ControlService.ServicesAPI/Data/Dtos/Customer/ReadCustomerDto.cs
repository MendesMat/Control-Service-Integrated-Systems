using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Data.Dtos.Proposal;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Customer;

/// <summary>
/// DTO (Data Transfer Object) para leitura de dados de um cliente.
/// Contém as propriedades necessárias para exibir as informações de um cliente individual ou de empresa.
/// </summary>

public class ReadCustomerDto : CustomerDtoBase
{
    // IndividualCustomer Properties
    public string? Cpf { get; set; }

    // CompanyCustomer Properties
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}