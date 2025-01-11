using Mendes.ControlService.ManagementAPI.Abstracts.Models;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

public class IndividualCustomer : CustomerBase
{
    [Required]
    public string Cpf { get; set; }
    [Required]
    public string FullName { get; set; }
}
