using Microsoft.EntityFrameworkCore;
using Mendes.ControlService.ManagementAPI.Abstracts;
using Mendes.ControlService.ManagementAPI.Models;

namespace Mendes.ControlService.ManagementAPI.Data.Context;

/// <summary>
/// Contexto de dados para a aplicação de gerenciamento de clientes.
/// Define os conjuntos de entidades (DbSet) e a configuração do modelo de dados.
/// </summary>

public class ManagementContext : DbContext
{
    public ManagementContext(DbContextOptions<ManagementContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Conjunto de clientes na base de dados.
    /// Este DbSet representa a tabela de clientes e suas entidades associadas.
    /// </summary>

    public DbSet<CustomerBase> Customers { get; set; }
    public DbSet<Proposal> Proposals { get; set; }

    /// <summary>
    /// Configuração do modelo de dados utilizando Fluent API.
    /// Define as entidades e como elas se relacionam no banco de dados.
    /// </summary>
    /// <param name="builder">Objeto que permite a configuração do modelo de dados.</param>

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CustomerBase>()
        .HasDiscriminator<string>("Type")
        .HasValue<IndividualCustomer>("Individual")
        .HasValue<CompanyCustomer>("Company");

        builder.Entity<Proposal>()
            .HasOne(p => p.Customer)
            .WithMany(c => c.Proposals)
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Proposal>()
            .HasOne(p => p.PayingEntity)
            .WithMany()
            .HasForeignKey(p => p.PayingEntityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Proposal>()
            .Property(p => p.Value)
            .HasPrecision(18, 2); // Define a precisão e escala para decimal
    }
}
