﻿using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.Companycustomer;

public class UpdateCompanyCustomerDto : CustomerDtoBase
{
    public string? Cnpj { get; set; }
    public string? LegalName { get; set; }
    public string BusinessName { get; set; } = string.Empty;
    public string? MunicipalRegistration { get; set; }
}
