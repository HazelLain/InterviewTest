using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(string firstName, string lastName, int initialBalance = 0) : base(firstName, lastName, initialBalance)
        {
        }
    }
}
