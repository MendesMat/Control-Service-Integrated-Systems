using Mendes.ControlService.ManagementAPI.Abstracts.Dtos;

namespace Mendes.ControlService.ManagementAPI.Data.Dtos.IndividualCustomer;

public class ReadIndividualCustomerDto : CustomerDtoBase
{
    public string Cpf { get; set; }
    public string FullName { get; set; }
}
