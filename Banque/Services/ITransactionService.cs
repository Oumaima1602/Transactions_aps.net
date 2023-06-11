namespace Banque.Services
{
    public interface ITransactionService
    {
        void Debit(int accountId, decimal amount);
        void Credit(int accountId, decimal amount);
    }
}
