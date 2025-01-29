﻿using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos;

/// <summary>
/// DTO (Data Transfer Object) para atualização de dados de um cliente.
/// Contém as propriedades necessárias para atualizar as informações de um cliente individual ou de empresa.
/// </summary>

public class UpdateCustomerDto : CustomerDtoBase
{
    // IndividualCustomer Properties
    public string? Cpf { get; set; }

    // CompanyCustomer Properties
    public string? LegalName { get; set; }
    public string? Cnpj { get; set; }
    public string? MunicipalRegistration { get; set; }
}
