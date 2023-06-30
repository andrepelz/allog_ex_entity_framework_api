using Microsoft.EntityFrameworkCore;
using Univali.Api.Entities;

namespace Univali.Api.DbContexts;

public class CustomerContext : DbContext {
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    public CustomerContext(DbContextOptions<CustomerContext> options)
    : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        var customer = modelBuilder.Entity<Customer>();

        customer
            .HasMany(c => c.Addresses)
            .WithOne(a => a.Customer)
            .HasForeignKey(a => a.CustomerId);
        
        customer
            .Property(customer => customer.Name)
            .HasMaxLength(50)
            .IsRequired();

        customer
            .Property(customer => customer.Cpf)
            .HasMaxLength(11)
            .IsRequired(false);

        customer
            .HasData(
                new Customer
                {
                    CustomerId = 1,
                    Name = "Linus Torvalds",
                    Cpf = "73473943096",


                },
                new Customer
                {
                    CustomerId = 2,
                    Name = "Bill Gates",
                    Cpf = "95395994076",
                });

        var address = modelBuilder.Entity<Address>();

        address
            .Property(address => address.Street)
            .HasMaxLength(50)
            .IsRequired();

        address
            .Property(address => address.City)
            .HasMaxLength(50)
            .IsRequired();

        address
            .HasOne(a => a.Customer)
            .WithMany(c => c.Addresses);
            
        address
            .HasData(
                    new Address
                    {
                        AddressId = 1,
                        Street = "Verão do Cometa",
                        City = "Elvira",
                        CustomerId = 1
                    },
                    new Address
                    {
                        AddressId = 2,
                        Street = "Borboletas Psicodélicas",
                        City = "Perobia",
                        CustomerId = 1
                    },
                    new Address
                    {
                        AddressId = 3,
                        Street = "Canção Excêntrica",
                        City = "Salandra",
                        CustomerId = 2
                    }
            );


        base.OnModelCreating(modelBuilder);
    }
}