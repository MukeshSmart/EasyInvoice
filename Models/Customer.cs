namespace InvoicingAPI.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<SolarInstallation> SolarInstallations { get; set; } = new List<SolarInstallation>();
    }
}