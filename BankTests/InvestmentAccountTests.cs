using BankProject.Models;
using NUnit.Framework;
using System;
using static BankProject.Enums.AccountEnums;

namespace Tests
{
    public class InvestmentAccountTests
    {
        private InvestmentAccount corporateInvestmentAccount;
        private InvestmentAccount corporateInvestmentAccountWithBalance;
        private InvestmentAccount individualInvestmentAccount;
        private InvestmentAccount individualInvestmentAccountWithBalance;

        [SetUp]
        public void Setup()
        {
            corporateInvestmentAccount = new InvestmentAccount("testFirstName", "testLastName", InvestmentAccountType.Corporate);
            corporateInvestmentAccountWithBalance = new InvestmentAccount("testFirstName", "testLastName", InvestmentAccountType.Corporate, 10000);
            individualInvestmentAccount = new InvestmentAccount("testFirstName", "testLastName", InvestmentAccountType.Individual);
            individualInvestmentAccountWithBalance = new InvestmentAccount("testFirstName", "testLastName", InvestmentAccountType.Individual, 10000);

        }

        [Test]
        public void InvestmentAccount_WhenDeposited_UpdatesBalance()
        {
            individualInvestmentAccount.Deposit(10);

            Assert.AreEqual(10, individualInvestmentAccount.Balance);
        }

        [Test]
        public void InvestmentAccount_WhenWithdrawn_UpdatesBalance()
        {
            individualInvestmentAccountWithBalance.Withdraw(10);

            Assert.AreEqual(9990, individualInvestmentAccountWithBalance.Balance);
        }

        [Test]
        public void CorporateInvestmentAccount_WhenWithdrawnOver500_UpdatesBalance()
        {
            corporateInvestmentAccountWithBalance.Withdraw(1000);

            Assert.AreEqual(9000, corporateInvestmentAccountWithBalance.Balance);
        }

        [Test]
        public void IndividualInvestmentAccount_WhenWithdrawnOverLimit_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => individualInvestmentAccountWithBalance.Withdraw(1000));
        }

        [Test]
        public void CheckingAccount_WhenDepositNegative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => corporateInvestmentAccount.Deposit(-10));
        }

        [Test]
        public void CheckingAccount_WhenWithdrawnNegative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => corporateInvestmentAccountWithBalance.Withdraw(-10));
        }
    }
}