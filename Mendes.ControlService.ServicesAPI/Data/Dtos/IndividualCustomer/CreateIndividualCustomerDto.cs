using Mendes.ControlService.ManagementAPI.Abstracts.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class CreateIndividualCustomerDto : CustomerDtoBase
{
    [Required]
    public string Cpf { get; set; }

    [Required]
    public string FullName { get; set; }

    // Sobrescrevendo as propriedades herdadas
    [Required]
    public new string Telephone1 { get; set; }

    [Required]
    public new string Email { get; set; }

    [Required]
    public new string Cep { get; set; }

    [Required]
    public new string Address { get; set; }

    [Required]
    public new int Number { get; set; }
}
