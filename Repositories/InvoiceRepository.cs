using InvoicingAPI.Data;
using InvoicingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicingAPI.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly InvoicingDbContext _context;

        public InvoiceRepository(InvoicingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync() =>
            await _context.Invoices.ToListAsync();

        public async Task<Invoice?> GetByIdAsync(int id) =>
            await _context.Invoices.FindAsync(id);

        public async Task<Invoice> AddAsync(Invoice invoice)
        {
            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return invoice;
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice != null)
            {
                _context.Invoices.Remove(invoice);
                await _context.SaveChangesAsync();
            }
        }
    }
}