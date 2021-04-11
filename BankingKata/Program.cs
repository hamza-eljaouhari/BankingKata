using System;

namespace BankingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            account.Deposit(500);
            account.Withdraw(100);
            account.Deposit(500);
            account.Withdraw(200);

            Console.WriteLine(account.PrintStatement());
            Console.ReadLine();
        }
    }
}
