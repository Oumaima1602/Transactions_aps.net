using static Banque.Models.Transaction;
using System;
using Banque.Data;
using Banque.Models;

namespace Banque.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly BankingDbContext _dbContext;

        public TransactionService(BankingDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Debit(int accountId, decimal amount)
        {
            // Rechercher le compte associé à l'ID du compte
            var account = _dbContext.Accounts.Find(accountId);

            if (account == null)
            {
                throw new Exception("Account not found");
            }

            // Vérifier si le solde est suffisant pour le débit
            if (account.Balance < amount)
            {
                throw new Exception("Insufficient balance");
            }

            // Effectuer le débit
            account.Balance -= amount;

            // Créer une nouvelle transaction pour enregistrer le débit
            var debitTransaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Date = DateTime.Now,
                Type = TransactionType.Debit
            };

            // Ajouter la transaction à la base de données
            _dbContext.Transactions.Add(debitTransaction);

            // Enregistrer les modifications dans la base de données
            _dbContext.SaveChanges();
        }

        public void Credit(int accountId, decimal amount)
        {
            // Rechercher le compte associé à l'ID du compte
            var account = _dbContext.Accounts.Find(accountId);

            if (account == null)
            {
                throw new Exception("Account not found");
            }

            // Effectuer le crédit
            account.Balance += amount;

            // Créer une nouvelle transaction pour enregistrer le crédit
            var creditTransaction = new Transaction
            {
                AccountId = accountId,
                Amount = amount,
                Date = DateTime.Now,
                Type = TransactionType.Credit
            };

            // Ajouter la transaction à la base de données
            _dbContext.Transactions.Add(creditTransaction);

            // Enregistrer les modifications dans la base de données
            _dbContext.SaveChanges();
        }


    }
}
