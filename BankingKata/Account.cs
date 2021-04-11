using System;
using System.Collections.Generic;
using System.Text;

namespace BankingKata
{
    public class Account
    {
        public int balance { get; set; }
        public Account(int initialBalance)
        {
            balance = initialBalance;
        }

        public Account()
        {
        }

        public void Deposit(int amount)
        {

        }

        public void Withdraw(int amount)
        {

        }

        public string PrintStatement()
        {
            return "";
        }
    }
}
