using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingKata;
using Xunit;
using System.Threading;
using System.Collections.Generic;

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


        [TestMethod]
        [DataRow(500, 100, 0)]
        [DataRow(230, 70, 20)]
        [DataRow(320, 100, 20)]
        public void Withdraw_BalanceDecreseasConcurrentlyWhenMultipleThreadsAreLaunched(int balance, int amountToWithdraw, int expectedBalance)
        {
            // Arrange

            List<Thread> threads = new List<Thread>();
            Account account = new Account(balance);

            // Creating threads

            for (int i = 0; i < 15; i++)
            {
                threads.Add(
                    new Thread(
                        new ThreadStart(() =>
                            {
                                // Act
                                account.Withdraw(amountToWithdraw);
                            })
                        )
                    );
            };

            foreach(Thread thread in threads)
            {
                thread.Start();
            }

            // Assert

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }
    }
}
