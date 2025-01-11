using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class UpdateIndividualCustomerDto
{
    [Required]
    public int Id { get; set; }
    public string Cpf { get; set; }
    public string FullName { get; set; }
}
