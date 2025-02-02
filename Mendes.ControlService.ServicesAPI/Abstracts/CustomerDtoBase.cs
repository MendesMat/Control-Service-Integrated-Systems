using Mendes.ControlService.ManagementAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace Mendes.ControlService.ManagementAPI.Abstracts;

/// <summary>
/// Classe base abstrata para objetos de transferência de dados (DTO) de clientes.
/// Contém informações comuns a todos os DTOs de clientes.
/// </summary>

public abstract class CustomerDtoBase
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;

    public string? Telephone1 { get; set; }
    public string? Telephone2 { get; set; }
    [EmailAddress]
    public string? Email { get; set; }
    [EmailAddress]
    public string? Email2 { get; set; }

    public string? Cep { get; set; }
    public string? Address { get; set; }
    public int Number { get; set; }
    public string? Complement { get; set; }
}
