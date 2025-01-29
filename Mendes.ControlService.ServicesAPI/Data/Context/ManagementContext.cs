using Microsoft.EntityFrameworkCore;
using Mendes.ControlService.ManagementAPI.Models;
using Mendes.ControlService.ManagementAPI.Abstracts;

namespace Mendes.ControlService.ManagementAPI.Data.Context;

public class ManagementContext : DbContext
{
    public ManagementContext(DbContextOptions<ManagementContext> options)
        : base(options)
    {
    }

    public DbSet<CustomerBase> Customers { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<CustomerBase>()
        .HasDiscriminator<string>("Type")
        .HasValue<IndividualCustomer>("Individual")
        .HasValue<CompanyCustomer>("Company");
    }
}
