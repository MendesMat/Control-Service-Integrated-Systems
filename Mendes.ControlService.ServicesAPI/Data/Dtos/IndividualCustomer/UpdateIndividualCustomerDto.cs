using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class UpdateIndividualCustomerDto : CustomerDtoBase
{
    public string? Cpf { get; set; }
    public string? FullName { get; set; }
}