using BankProject.Models;
using NUnit.Framework;
using System;

namespace Tests
{
    public class CheckingAccountTests
    {
        CheckingAccount checkingAccount;
        CheckingAccount checkingAccountWithBalance;
       
        [SetUp]
        public void Setup()
        {
            checkingAccount = new CheckingAccount("testFirstName", "testLastName");
            checkingAccountWithBalance = new CheckingAccount("testFirstName", "testLastName", 50);
        }

        [Test]
        public void CheckingAccount_WhenDeposited_UpdatesBalance()
        {
            checkingAccount.Deposit(10);

            Assert.AreEqual(10, checkingAccount.Balance);
        }

        [Test]
        public void CheckingAccount_WhenWithdrawn_UpdatesBalance()
        {
            checkingAccountWithBalance.Withdraw(10);

            Assert.AreEqual(40, checkingAccountWithBalance.Balance);
        }

        [Test]
        public void CheckingAccount_WhenDepositNegative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => checkingAccountWithBalance.Deposit(-10));
        }

        [Test]
        public void CheckingAccount_WhenWithdrawnNegative_ThrowsException()
        {
            Assert.Throws<ArgumentException>(() => checkingAccountWithBalance.Withdraw(-10));
        }

        [Test]
        public void CheckingAccount_Name_ReturnsCorrectly()
        {
            Assert.AreEqual("testFirstName testLastName", checkingAccount.AccountHolder.GetName());
        }
    }
}