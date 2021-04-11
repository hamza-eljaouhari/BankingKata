using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingKata;
using Xunit;

namespace BankingKataUnitTests
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        [DataRow(500, 100, 600)]
        [DataRow(230, 70, 300)]
        [DataRow(320, 100, 420)]
        public void Deposit_BalanceIncreasesWhenMakingADeposit(int balance, int amountToDeposit, int expectedBalance)
        {
            // Arrange
            Account account = new Account(balance);
            IRegistryRecord deposit = new Deposit(account.balance, amountToDeposit);

            // Act

            account.balance = deposit.Execute();

            // Assert

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }


        [TestMethod]
        [DataRow(500, 100, 400)]
        [DataRow(230, 70, 160)]
        [DataRow(320, 100, 220)]
        public void Withdraw_BalanceDecreseasWhenMakingAWithdrawal(int balance, int amountToWithdraw, int expectedBalance)
        {
            // Arrange
            Account account = new Account(balance);
            IRegistryRecord withdrawal = new Withdrawal(account.balance, amountToWithdraw);

            // Act

            account.balance = withdrawal.Execute();

            // Assert

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }
    }
}
