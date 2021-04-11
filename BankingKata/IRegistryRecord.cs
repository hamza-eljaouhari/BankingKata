using System;
using System.Collections.Generic;
using System.Text;

namespace BankingKata
{
    public interface IRegistryRecord
    {
        public int Amount { get; set; }
        public DateTime Datetime { get; set; }
        public int Balance { get; set; }

        public int Execute();

    }
}
