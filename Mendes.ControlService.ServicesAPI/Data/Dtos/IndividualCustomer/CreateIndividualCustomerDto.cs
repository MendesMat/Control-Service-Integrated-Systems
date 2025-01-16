using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class CreateIndividualCustomerDto : CustomerDtoBase
{
    public string? Cpf { get; set; }
    [Required]
    public string FullName { get; set; } = string.Empty;
}