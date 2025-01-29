using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Models;

public class IndividualCustomer : CustomerBase
{
    public string? Cpf { get; set; }
}
