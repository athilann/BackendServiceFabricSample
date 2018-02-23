using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAccess.Entity
{
    [Table("Transactions")]
    public class Transaction
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionID { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        [Required]
        public string PayerName { get; set; }
        [Required]
        public string PayerBank { get; set; }
        [Required]
        public string PayerBankAgency { get; set; }
        [Required]
        public string PayerBankAccount { get; set; }
        [Required]
        public string RecipientName { get; set; }
        [Required]
        public string RecipientBank { get; set; }
        [Required]
        public string RecipientBankAgency { get; set; }
        [Required]
        public string RecipientBankAccount { get; set; }
        [Required]
        public decimal Value { get; set; }
        [Required]
        public string TransactionType { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public int Active { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }
    }
}
