using System;

namespace BankProject.Models
{
    public abstract class Account
    {
        public Account(
            string firstName,
            string lastName,
            decimal initialBalance)
        {
            AccountHolder = new AccountHolder(firstName, lastName);
            GenerateAccountNumber();
            Balance = initialBalance;
        }

        public AccountHolder AccountHolder { get; }

        public decimal Balance { get; private set; }

        public int AccountNumber { get; private set; }

        private void GenerateAccountNumber()
        {
            AccountNumber = DateTime.Now.GetHashCode();
        }

        public virtual void Deposit(decimal amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("The deposit amount must be positive");
            }
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("The withdraw amount must be positive");
            }
            Balance -= amount;
        }
    }
}
