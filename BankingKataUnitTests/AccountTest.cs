using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingKata;
using Xunit;

namespace BankingKataUnitTests
{
    [TestClass]
    public class AccountTest
    {
        [Theory]
        [TestMethod]
        [InlineData(500, 100, 600)]
        [InlineData(230, 70, 300)]
        [InlineData(320, 100, 420)]
        public void Deposit_AmountIncreasesWhenMakingADeposit(int balance, int amountToDeposit, int expectedBalance)
        {
            // Arrange
            Account account = new Account(balance);

            // Act

            account.Deposit(amountToDeposit);

            // Assert

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }
    }
}
