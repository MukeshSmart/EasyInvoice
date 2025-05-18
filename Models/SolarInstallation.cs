using System;

namespace InvoicingAPI.Models
{
    public class SolarInstallation
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Address { get; set; } = string.Empty;
        public DateTime InstallationDate { get; set; }

        // New properties for stage tracking
        public InstallationStage Stage { get; set; } = InstallationStage.PendingExecutiveReview;
        public string? ExecutiveComments { get; set; }
        public DateTime? ExecutiveReviewDate { get; set; }
        public string? CompanyComments { get; set; }
        public DateTime? CompanyReviewDate { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}