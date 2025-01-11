using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class DeleteIndividualCustomerDto
{
    [Required]
    public int Id { get; set; }
}
