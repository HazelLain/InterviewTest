using System.Collections.Generic;
using BankProject.Models;

namespace BankProject
{
    public interface IBank
    {
        Dictionary<int, Account> Accounts { get; }
        string Name { get; }
        void AddAccount(Account account);
        void Deposit(int accountNumber, decimal depositAmount);
        void Transfer(int sourceAccountNumber, int destinationAccountNumber, decimal transferAmount);
        void Withdraw(int accountNumber, decimal withdrawAmount);
        Account GetAccount(int accountNumber);
    }
}