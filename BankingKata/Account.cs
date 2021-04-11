using System;
using System.Collections.Generic;
using System.Text;

namespace BankingKata
{
    public class Account
    {
        public int balance;
        public List<IRegistryRecord> registry;
        public Account(int initialBalance)
        {
            balance = initialBalance;
            registry = new List<IRegistryRecord>();
        }

        public void Deposit(int amount)
        {
           IRegistryRecord deposit = new Deposit(balance, amount);

            balance = deposit.Execute();

            registry.Add(deposit);
        }

        public void Withdraw(int amount)
        {
            IRegistryRecord withdrawal = new Withdrawal(balance, amount);

            balance = withdrawal.Execute();

            registry.Add(withdrawal);
        }

        public string PrintStatement()
        {

            string statement = "";

            string[] headings = new string[] { "Date", "Amount", "Balance" };

            registry.ForEach(delegate (IRegistryRecord record)
            {
                statement += record.Datetime.Day + "/";
                statement += record.Datetime.Month + "/";
                statement += record.Datetime.Year;

                statement += "\t";

                if (record.GetType().Name == "Deposit")
                {
                    statement += "+";
                }

                if (record.GetType().Name == "Withdrawal")
                {
                    statement += "-";
                }

                statement += record.Amount;
                statement += "\t";
                statement += record.Balance;
                statement += "\n";
            });

            return statement;
        }
    }
}
