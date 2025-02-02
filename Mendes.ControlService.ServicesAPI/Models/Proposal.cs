using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mendes.ControlService.ManagementAPI.Models;

/// <summary>
/// Representa um cliente do tipo individual.
/// </summary>

public class Proposal : IEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    [ForeignKey("Customer")]
    public int CustomerId { get; set; }
    [Required]
    public required CustomerBase Customer { get; set; }

    [ForeignKey("PayingEntity")]
    public int? PayingEntityId { get; set; }
    public CustomerBase? PayingEntity { get; set; }

    public decimal Value { get; set; }
}