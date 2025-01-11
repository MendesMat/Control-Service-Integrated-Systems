using Microsoft.EntityFrameworkCore;
using Mendes.ControlService.ManagementAPI.Models;
using Mendes.ControlService.ManagementAPI.Abstracts.Models;

namespace Mendes.ControlService.ManagementAPI.Data.Context;

public class ManagementContext : DbContext
{
    public ManagementContext(DbContextOptions<ManagementContext> options)
        : base(options)
    {
    }

    public DbSet<CustomerBase> Customers { get; set; }
    public DbSet<IndividualCustomer> IndividualCustomers { get; set; }
    public DbSet<CompanyCustomer> CompanyCustomers { get; set; }
    public DbSet<Proposal> Proposals { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Proposal>()
            .HasOne(proposal => proposal.Customer)
            .WithMany(customer => customer.Proposals)
            .HasForeignKey(proposal => proposal.CustomerId);
    }
}
