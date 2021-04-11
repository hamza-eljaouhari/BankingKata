using System;
using System.Collections.Generic;
using System.Text;

namespace BankingKata
{
    public class Withdrawal : RegistryRecord, IRegistryRecord {
        public Withdrawal(int balance, int amount) : base(balance, amount)
        {
        }

        public override int Execute()
        {
            Balance = Balance - Amount;

            return Balance;
        }
    }
}
