using InvoicingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicingAPI.Data
{
    public class InvoicingDbContext : DbContext
    {
        public InvoicingDbContext(DbContextOptions<InvoicingDbContext> options)
            : base(options) { }

        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<SolarInstallation> SolarInstallations { get; set; }
    }
}