using Mendes.ControlService.ManagementAPI.Abstracts;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Models;

public class Proposal
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public int CustomerId { get; set; }
    public CustomerBase? Customer { get; set; }
}