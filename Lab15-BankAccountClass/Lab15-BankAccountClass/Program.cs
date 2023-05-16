using System;

namespace Lab15_BankAccountClass
{
    class BankAccount
    {
        // create the balance field
        private double balance;

        //create a constructor
        public BankAccount()
        {
            balance = 0;
        }

        //create the deposit function
        public void Deposit(double amount)
        {
            balance += amount;
        }

        // create the withdrawal function
        public void Withdrawal(double amount)
        { 
            balance -= amount; 
        }

        //create an accessing function to find what your current balance is
        public double GetBalance() // returns the balance in decimal
        {
            return balance;
        }
    }
    internal class Program
    {
        static void Main()
        {
            BankAccount acct = new BankAccount();

            acct.Deposit(200);
            acct.Withdrawal(40);

            Console.WriteLine("The final balance is {0:c}", acct.GetBalance());

            Console.ReadLine();
        }
    }
}
