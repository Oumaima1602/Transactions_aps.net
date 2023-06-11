namespace Banque.Models
{
    public class Account
    {
        public int Id { get; set; }
        public string AccountName { get; set; }
        public decimal Balance { get; set; }

        public ICollection<Transaction> Transactions { get; set; }


    }
}
