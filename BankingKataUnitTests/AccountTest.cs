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
            
            // Act

            account.Deposit(amountToDeposit);

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


            // Act

            account.Withdraw(amountToWithdraw);

            // Assert

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }
    }
}
