using System;

namespace ConformityCheck.Services.ViewModels
{
    public class ConformityDTO
    {
        public string ConformityType { get; set; }

        public string SupplierNumber { get; set; }

        public string SupplierName { get; set; }

        public DateTime IssueDate { get; set; } //vsichki dates da sa v UTC, i tuk i na servera i na DB-a!!!

        public DateTime? ConformationAcceptanceDate { get; set; }

        public bool IsConfirmed { get; set; }
    }
}