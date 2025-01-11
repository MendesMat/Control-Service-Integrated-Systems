using Mendes.ControlService.ManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Abstracts.Models;

public abstract class CustomerBase
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Telephone1 { get; set; }
    public string Telephone2 { get; set; }
    [Required]
    public string Email { get; set; }
    public string Email2 { get; set; }

    [Required]
    public string Cep { get; set; }
    [Required]
    public string Address { get; set; }
    [Required]
    public int Number { get; set; }
    public string Complement { get; set; }

    public CustomerBase PayingEntity { get; set; }
    public List<Proposal> Proposals { get; set; }
}
