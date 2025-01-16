﻿using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

public class CompanyCustomer : CustomerBase
{
    public string? Cnpj { get; set; }
    public string? LegalName { get; set; }
    [Required]
    public string BusinessName { get; set; } = string.Empty;
    public string? MunicipalRegistration { get; set; }
}
