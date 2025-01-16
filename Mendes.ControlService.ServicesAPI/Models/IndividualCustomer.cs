using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

public class IndividualCustomer : CustomerBase
{
    public string? Cpf { get; set; }
    [Required]
    public string FullName { get; set; } = string.Empty;
}
