using InvoicingAPI.Data;
using InvoicingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicingAPI.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly InvoicingDbContext _context;

        public CustomerRepository(InvoicingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetAllAsync() =>
            await _context.Customers.Include(c => c.Invoices).ToListAsync();

        public async Task<Customer?> GetByIdAsync(int id) =>
            await _context.Customers.Include(c => c.Invoices).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Customer> AddAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task UpdateAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }
    }
}