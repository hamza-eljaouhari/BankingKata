using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankingKata;
using Xunit;
using System.Threading;
using System.Collections.Generic;
using System;

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

            for (int i = 0; i < 20; i++)
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

            foreach (Thread thread in threads)
            {
                thread.Start();
            }

            // Assert

            //11 / 4 / 2021 + 500    1500
            //11 / 4 / 2021 + 100    1600
            //11 / 4 / 2021 - 100    1500
            //11 / 4 / 2021 + 500    2000
            //11 / 4 / 2021 - 200    1800
            //11 / 4 / 2021 + 500    2300

            Xunit.Assert.Equal(expectedBalance, account.balance);
        }

        [TestMethod]
        [DataRow("8/8/2021\t-500\t500\n9/9/2021\t+200\t700\n")]
        public void PrintStatement_StatementShouldIncludeHeaderAndRegistryOperationsTable(string expectedStatement)
        {
            // Arrange

            // 0 for dummy data

            Account account = new Account(0);

            account.registry = Transactions.Data;

            // Act

            string printStatement = account.PrintStatement();

            // Assert

            Xunit.Assert.Equal(expectedStatement, printStatement);
        }
    }

    public class Transactions
    {
            public static List<IRegistryRecord> Data = new List<IRegistryRecord>
            {
                new Withdrawal(500, 500, new DateTime(2021, 08, 08)),
                new Deposit(700, 200, new DateTime(2021, 09, 09))
            };
    }
}
