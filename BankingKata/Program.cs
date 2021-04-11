using System;

namespace BankingKata
{
    class Program
    {
        static void Main(string[] args)
        {
            Account account = new Account(1000);
            account.Deposit(500);
            account.Deposit(100);
            account.Withdraw(100);
            account.Deposit(500);
            account.Withdraw(200);
            account.Deposit(500);

            Console.WriteLine(account.PrintStatement());
            Console.ReadLine();
        }
    }
}
