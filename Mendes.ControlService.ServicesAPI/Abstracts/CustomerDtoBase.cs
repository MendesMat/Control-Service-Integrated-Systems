using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Abstracts;

public class CustomerDtoBase
{
    [Key]
    [Required]
    public int Id { get; }

    public string? Telephone1 { get; set; }
    public string? Telephone2 { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [EmailAddress]
    public string? Email2 { get; set; }

    public string? Cep { get; set; }
    public string? Address { get; set; }
    public int? Number { get; set; }
    public string? Complement { get; set; }

    public CustomerBase? PayingEntity { get; set; }
}
