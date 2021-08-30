using System;
using System.Collections.Generic;
using System.Text;

namespace BankProject.Models
{
    public class AccountHolder
    {
        public AccountHolder(string firstname, string lastName)
        {
            FirstName = firstname;
            LastName = lastName;
        }

        private string FirstName { get; }
        private string LastName { get; }

        public string GetName()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
