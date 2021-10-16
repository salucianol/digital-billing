using DigitalBilling.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalBilling.Infrastructure.Data {
    public class InvoiceNpgsqlDbContext : DbContext {
        public InvoiceNpgsqlDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions){
        }
        public DbSet<Invoice> Invoices {  get; set; }
    }
}
