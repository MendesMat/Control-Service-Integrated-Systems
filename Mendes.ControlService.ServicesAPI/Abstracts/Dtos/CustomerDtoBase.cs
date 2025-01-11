using Mendes.ControlService.ManagementAPI.Abstracts.Models;

namespace Mendes.ControlService.ManagementAPI.Abstracts.Dtos;

public class CustomerDtoBase
{
    public string Id { get; }

    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    public string Email { get; set; }
    public string Email2 { get; set; }

    public string Cep { get; set; }
    public string Address { get; set; }
    public int Number { get; set; }
    public string Complement { get; set; }

    public CustomerBase PayingEntity { get; set; }
}
