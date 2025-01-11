using Mendes.ControlService.ManagementAPI.Abstracts.Models;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

public class CompanyCustomer : CustomerBase
{
    [Required]
    public string Cnpj { get; set; }
    [Required]
    public string LegalName { get; set; }
    [Required]
    public string BusinessName { get; set; }
    public string MunicipalRegistration { get; set; }
}
