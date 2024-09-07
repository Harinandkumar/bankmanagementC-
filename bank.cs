//////////////bank management/////////////
///////////////right side me run krke output dikh jayega ya to copy krke bhi dekh sakte h  ////////////////

using System;
using System.Threading;
namespace BankAccount
{
    class Transaction
    {
        public string Type { get; set; }
        public double Amount { get; set; }
    }

    class Account
    {
        private string accountHolder;
        private int accountNumber;
        private double balance;
        private Transaction[] transactions;
        private int transactionCount;

        public Account(string name, int number, double initialBalance)
        {
            accountHolder = name;
            accountNumber = number;
            balance = initialBalance;
            transactions = new Transaction[50];
            transactionCount = 0;
            Console.WriteLine("\n\t\tYour account is creating please wait");
            for (int i = 0; i < 5; i++)
            {
                Console.Write(".");
                System.Threading.Thread.Sleep(1000);
            }
            Console.Clear();
            Console.WriteLine("\n\t\tYour Account created successfully");
              Console.WriteLine("\n\t\t\t\t Welcome,"+name);
        }

        public void Deposit(double amount)
        {
            balance += amount;
            if (transactionCount < 50)
            {
                transactions[transactionCount++] = new Transaction { Type = "Deposit", Amount = amount };
            }
            Console.Clear();
            Console.WriteLine("Deposit of $" + amount + " successful!");
        }

        public void DisplayAccountDetails()
        {
            Console.WriteLine("Account Holder: " + accountHolder);
            Console.WriteLine("Account Number: " + accountNumber);
            Console.WriteLine("Current Balance: $" + balance);
        }

        public void Withdraw(double amount)
        {
            if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                balance -= amount;
                if (transactionCount < 50)
                {
                    transactions[transactionCount++] = new Transaction { Type = "Withdrawal", Amount = amount };
                }
                Console.Clear();
                Console.WriteLine("Withdrawal of $" + amount + " successful!");
            }
        }

        public void DisplayTransactions()
        {
            Console.Clear();
            Console.WriteLine("Transaction History:");
            for (int i = 0; i < transactionCount; i++)
            {
                Console.WriteLine(transactions[i].Type + ": $" + transactions[i].Amount);
            }
        }

        public void CheckBalance()
        {
            Console.Clear();
            Console.WriteLine("Current Balance: $" + balance);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter account holder's name: ");
            string name = Console.ReadLine();
            Console.Write("Enter account number: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter initial balance: ");
            double initialBalance = Convert.ToDouble(Console.ReadLine());

            Account myAccount = new Account(name, number, initialBalance);

            int choice;
            do
            {
                Console.WriteLine("\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Display Transactions\n5. Exit\n");
                Console.Write("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter amount to deposit: ");
                        double depositAmount = Convert.ToDouble(Console.ReadLine());
                        myAccount.Deposit(depositAmount);
                        break;
                    case 2:
                        Console.Write("Enter amount to withdraw: ");
                        double withdrawAmount = Convert.ToDouble(Console.ReadLine());
                        myAccount.Withdraw(withdrawAmount);
                        break;
                    case 3:
                        myAccount.CheckBalance();
                        break;
                    case 4:
                        myAccount.DisplayTransactions();
                        break;
                    case 5:
                        Console.WriteLine("Exiting");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.Write("\t\t\t.");
                            System.Threading.Thread.Sleep(1000);
                        }
                        Console.Clear();
                        Console.WriteLine("\n\t\tExit successfully");
                        break;
                    default:
                        Console.WriteLine("wrong! Please try again.");
                        break;
                }
            } while (choice != 5);
        }
    }
}
