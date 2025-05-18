using InvoicingAPI.Models;

namespace InvoicingAPI.Repositories
{
    public interface ISolarInstallationRepository
    {
        Task<IEnumerable<SolarInstallation>> GetAllAsync();
        Task<SolarInstallation?> GetByIdAsync(int id);
        Task<SolarInstallation> AddAsync(SolarInstallation installation);
        Task UpdateAsync(SolarInstallation installation);
        Task DeleteAsync(int id);
    }
}