using System.Security.Principal;

namespace Banque.Models
{
    public class Transaction
    {
       
            public int Id { get; set; }
            public decimal Amount { get; set; }
            public DateTime Date { get; set; }
            public TransactionType Type { get; set; }

            // Foreign key
            public int AccountId { get; set; }
            // Navigation property
            public Account Account { get; set; }

            public enum TransactionType
            {
                Debit,
                Credit,
            }
    }
}
