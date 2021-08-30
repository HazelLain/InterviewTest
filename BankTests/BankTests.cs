using BankProject;
using BankProject.Models;
using NUnit.Framework;
using System;
using static BankProject.Enums.AccountEnums;

namespace Tests
{
    public class BankTests
    {
        private const string BankName = "TestBank";
        private IBank bank;
        private InvestmentAccount corporateInvestmentAccount;
        private InvestmentAccount corporateInvestmentAccountWithBalance;
        private InvestmentAccount individualInvestmentAccount;
        private InvestmentAccount individualInvestmentAccountWithBalance;

        [SetUp]
        public void Setup()
        {
            bank = new Bank(BankName);

            corporateInvestmentAccount = new InvestmentAccount("testFirstName1", "testLastName1", InvestmentAccountType.Corporate);
            corporateInvestmentAccountWithBalance = new InvestmentAccount("testFirstName2", "testLastName2", InvestmentAccountType.Corporate, 10000);
            individualInvestmentAccount = new InvestmentAccount("testFirstName3", "testLastName3", InvestmentAccountType.Individual);
            individualInvestmentAccountWithBalance = new InvestmentAccount("testFirstName4", "testLastName4", InvestmentAccountType.Individual, 10000);

            bank.AddAccount(corporateInvestmentAccount);
            bank.AddAccount(corporateInvestmentAccountWithBalance);
            bank.AddAccount(individualInvestmentAccount);
            bank.AddAccount(individualInvestmentAccountWithBalance);
        }

        [Test]
        public void Bank_HasName()
        {
            Assert.AreEqual("TestBank", bank.Name);
        }

        [Test]
        public void Bank_Withdraw_WithdrawsFromAccount()
        {
            bank.Withdraw(corporateInvestmentAccountWithBalance.AccountNumber, 1000);

            var account = bank.GetAccount(corporateInvestmentAccountWithBalance.AccountNumber);

            Assert.AreEqual(9000, account.Balance);
        }

        [Test]
        public void Bank_WithdrawOverLimitFromIndividualInvestmentAccount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(()=>bank.Withdraw(individualInvestmentAccountWithBalance.AccountNumber, 1000));
        }

        [Test]
        public void Bank_Deposit_DepositsInAccount()
        {
            bank.Deposit(individualInvestmentAccount.AccountNumber, 1000);

            var account = bank.GetAccount(individualInvestmentAccount.AccountNumber);

            Assert.AreEqual(1000, account.Balance);
        }

        [Test]
        public void Bank_Transfer_TransfersBalanceBetweenAccounts()
        {
            bank.Transfer(corporateInvestmentAccountWithBalance.AccountNumber, corporateInvestmentAccount.AccountNumber, 10000);

            var sourceAccount = bank.GetAccount(corporateInvestmentAccountWithBalance.AccountNumber);
            var destinationAccount = bank.GetAccount(corporateInvestmentAccount.AccountNumber);

            Assert.AreEqual(10000, destinationAccount.Balance);
            Assert.AreEqual(0, sourceAccount.Balance);
        }

        [Test]
        public void Bank_WithdrawFromInvalidAccount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bank.Withdraw(1, 1000));
        }

        [Test]
        public void Bank_DepositToInvalidAccount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bank.Deposit(1, 1000));
        }

        [Test]
        public void Bank_TransferFromInvalidAccount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bank.Transfer(1, corporateInvestmentAccount.AccountNumber, 1000));
        }

        [Test]
        public void Bank_TransferToInvalidAccount_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => bank.Transfer(corporateInvestmentAccount.AccountNumber, 1, 1000));
        }
    }
}
