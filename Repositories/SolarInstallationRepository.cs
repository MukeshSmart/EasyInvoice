using InvoicingAPI.Data;
using InvoicingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace InvoicingAPI.Repositories
{
    public class SolarInstallationRepository : ISolarInstallationRepository
    {
        private readonly InvoicingDbContext _context;

        public SolarInstallationRepository(InvoicingDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<SolarInstallation>> GetAllAsync() =>
            await _context.SolarInstallations.Include(s => s.Customer).ToListAsync();

        public async Task<SolarInstallation?> GetByIdAsync(int id) =>
            await _context.SolarInstallations.Include(s => s.Customer).FirstOrDefaultAsync(s => s.Id == id);

        public async Task<SolarInstallation> AddAsync(SolarInstallation installation)
        {
            _context.SolarInstallations.Add(installation);
            await _context.SaveChangesAsync();
            return installation;
        }

        public async Task UpdateAsync(SolarInstallation installation)
        {
            _context.Entry(installation).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var installation = await _context.SolarInstallations.FindAsync(id);
            if (installation != null)
            {
                _context.SolarInstallations.Remove(installation);
                await _context.SaveChangesAsync();
            }
        }
    }
}