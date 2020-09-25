using System;

namespace ConformityCheck.Services.ViewModels
{
    public class ConformityDTO
    {
        public string ConformityType { get; set; }

        public string SupplierNumber { get; set; }

        public string SupplierName { get; set; }

        public DateTime IssueDate { get; set; }

        public DateTime? ConformationAcceptanceDate { get; set; }

        public bool IsConfirmed { get; set; }
    }
}