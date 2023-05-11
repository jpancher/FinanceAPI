using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace financeAPI.Models
{
    public class Transaction
    {
        [Key]
        public Guid Guid { get; set; }
        [Required]
        public DateTime AccrualDate { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        public DateTime PaymentDate { get; set;}
        [Required]
        public string Status { get; set; }
        [Precision(18, 4)]
        [Required]
        public Decimal Value { get; set; }
        [Precision(18, 4)]
        public Decimal PenaltyAndInterestOrDiscount { get; set; }
        public string Description { get; set; }
        public Supplier Supplier { get; set; }
        public ChartOfAccounts ChartOfAccounts { get; set; }
        public CostCenter CostCenter { get; set; }        
        [Required]
        public TransactionType TransactionType { get; set; }        
        public BankAccount BankAccount { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedUser { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedUser { get; set; }

        public override string ToString()
        {
            return $"{Description}:{TransactionType}:{DueDate}:{Value}:{Status}";
        }

    }
}





//[Key]
//public Guid Guid { get; set; }
//public DateTime AccrualDate { get; set; }
//public DateTime DueDate { get; set; }
//public DateTime PaymentDate { get; set; }
//public string Status { get; set; }
//[Precision(18, 4)]
//public Decimal Value { get; set; }
//[Precision(18, 4)]
//public Decimal PenaltyAndInterestOrDiscount { get; set; }
//public string Description { get; set; }
//public Guid SupplierGuid { get; set; }
//public int AccountId { get; set; }
//public int CostCenterId { get; set; }
//public string Type { get; set; }
//public int BankAccountId { get; set; }