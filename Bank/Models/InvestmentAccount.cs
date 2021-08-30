using System;
using static BankProject.Enums.AccountEnums;

namespace BankProject.Models
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(
            string firstName,
            string lastName,
            InvestmentAccountType accountType,
            decimal initialBalance = 0) : base(firstName, lastName, initialBalance)
        {
            AccountType = accountType;
        }

        private InvestmentAccountType AccountType { get; set; }

        private decimal WithdrawLimit
        {
            get
            {
                return AccountType == InvestmentAccountType.Individual ? 500 : int.MaxValue;
            }
        }

        public override void Withdraw(decimal amount)
        {
            if(amount >= WithdrawLimit)
            {
                throw new ArgumentException("Over Withdraw Limit");
            }
            base.Withdraw(amount);
        }
    }

    
}
