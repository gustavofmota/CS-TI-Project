using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TI_Project.Models
{
    public class Expense
    {
        [Key]
        public int ExpenseId { get; set; }

        public string UserId { get; set; }

        [Column(TypeName = "decimal")]
        public decimal Amount { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? PaymentMethodId { get; set; }

        public virtual Category Category { get; set; }
        public virtual PaymentMethod PaymentMethod { get; set; }
    }

}