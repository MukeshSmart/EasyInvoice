namespace InvoicingAPI.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal Amount { get; set; }

        // Foreign key and navigation property
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;
    }
}