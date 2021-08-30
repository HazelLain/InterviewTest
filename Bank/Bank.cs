using System;
using System.Collections.Generic;
using BankProject.Models;

namespace BankProject
{
    public class Bank : IBank
    {
        public Bank(string name)
        {
            Name = name;
            Accounts = new Dictionary<int, Account>();
        }

        public string Name { get; private set; }

        public Dictionary<int, Account> Accounts { get; }

        public void AddAccount(Account account)
        {
            Accounts.Add(account.AccountNumber, account);
        }

        public Account GetAccount(int accountNumber)
        {
            Account account;
            if (Accounts.TryGetValue(accountNumber, out account))
            {
                return account;
            }
            return null;
        }

        public void Deposit(int accountNumber, decimal depositAmount)
        {
            Account account;
            if (Accounts.TryGetValue(accountNumber, out account))
            {
                account.Deposit(depositAmount);
            }
            else
            {
                throw new ArgumentException("Account number not valid");
            }
        }

        public void Withdraw(int accountNumber, decimal withdrawAmount)
        {
            Account account;
            if (Accounts.TryGetValue(accountNumber, out account))
            {
                account.Withdraw(withdrawAmount);
            }
            else
            {
                throw new ArgumentException("Account number not valid");
            }
        }

        public void Transfer(int sourceAccountNumber, int destinationAccountNumber, decimal transferAmount)
        {
            Account sourceAccount;
            Account destinationAccount;

            if (Accounts.TryGetValue(sourceAccountNumber, out sourceAccount))
            {
                if (Accounts.TryGetValue(destinationAccountNumber, out destinationAccount))
                {
                    sourceAccount.Withdraw(transferAmount);
                    destinationAccount.Deposit(transferAmount);
                }
                else
                {
                    throw new ArgumentException("Destination account number invalid");
                }

            }
            else
            {
                throw new ArgumentException("Source account number invalid");
            }

        }
    }
}
