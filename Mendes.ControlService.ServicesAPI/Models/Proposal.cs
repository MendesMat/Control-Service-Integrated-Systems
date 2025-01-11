using Mendes.ControlService.ManagementAPI.Abstracts.Models;

namespace Mendes.ControlService.ManagementAPI.Models;

public class Proposal
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public CustomerBase Customer { get; set; }
}