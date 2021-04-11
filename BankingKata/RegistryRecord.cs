using System;
using System.Collections.Generic;
using System.Text;

namespace BankingKata
{
    public abstract class RegistryRecord : IRegistryRecord
    {
        protected int _amount;
        public int Amount { get => _amount; set => _amount = value; }

        public DateTime _datetime;
        public DateTime Datetime { get => _datetime; set => _datetime = value; }

        protected int _balance;
        public int Balance { get => _balance; set => _balance = value; }

        public RegistryRecord(int balance, int amount, DateTime datetime)
        {
            Balance = balance;
            Amount = amount;
            Datetime = datetime;
        }

        public abstract int Execute();
    }
}
