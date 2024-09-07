#include <iostream>
#include <string>
#include <windows.h>
using namespace std;
const int MAX_TRANSACTIONS = 50;

struct Transaction
{
    string type;
    double amount;
};

class Account
{
private:
    string accountHolder;
    int accountNumber;
    double balance;
    Transaction transactions[MAX_TRANSACTIONS];
    int transactionCount;

public:
    // Constructor
    Account(string name, int number, double initialBalance)
    {
        accountHolder = name;
        accountNumber = number;
        balance = initialBalance;
        transactionCount = 0;
        cout << "\n \t \t Your account is creating please wait";
        for (int i = 0; i < 5; i++)
        {
            cout << ".";
            Sleep(1000);
        }
        system("CLS");
        cout << "\n \t \t Your Account created successfully ";
    }
    // deposit money
    void deposit(double amount)
    {
        balance += amount;
        if (transactionCount < MAX_TRANSACTIONS)
        {
            transactions[transactionCount++] = {"Deposit", amount};
        }
        system("CLS");
        cout << "Deposit of $" << amount << " successful!" << endl;
    }

    //  display account details
    void displayAccountDetails()
    {
        cout << "Account Holder: " << accountHolder << endl;
        cout << "Account Number: " << accountNumber << endl;
        cout << "Current Balance: $" << balance << endl;
    }

    // withdraw money
    void withdraw(double amount)
    {
        if (amount > balance)
        {
            cout << "Insufficient balance!" << endl;
        }
        else
        {
            balance -= amount;
            if (transactionCount < MAX_TRANSACTIONS)
            {
                transactions[transactionCount++] = {"Withdrawal", amount};
            }
            system("CLS");
            cout << "Withdrawal of $" << amount << " successful!" << endl;
        }
    }

    // transaction history
    void displayTransactions()
    {
        system("CLS");
        cout << "Transaction History:" << endl;
        for (int i = 0; i < transactionCount; i++)
        { // Loop through transactions
            cout << transactions[i].type << ": $" << transactions[i].amount << endl;
        }
    }

    // check balance
    void checkBalance()
    {
        system("CLS");
        cout << "Current Balance: $" << balance << endl;
    }
};

int main()
{
    string name;
    int number;
    double initialBalance;

    cout << "Enter account holder's name: ";
    getline(cin, name);
    cout << "Enter account number: ";
    cin >> number;
    cout << "Enter initial balance: ";
    cin >> initialBalance;

    Account myAccount(name, number, initialBalance);

    int choice;
    do
    {
        cout << "\n1. Deposit\n2. Withdraw\n3. Check Balance\n4. Display Transactions\n5. Exit\n";
        cout << "Enter your choice: ";
        cin >> choice;

        switch (choice)
        {
        case 1:
        {
            double depositAmount;
            system("CLS");
            cout << "Enter amount to deposit: ";
            cin >> depositAmount;
            myAccount.deposit(depositAmount);
            break;
        }
        case 2:
        {
            double withdrawAmount;
            system("CLS");
            cout << "Enter amount to withdraw: ";
            cin >> withdrawAmount;
            myAccount.withdraw(withdrawAmount);
            break;
        }
        case 3:
            system("CLS");
            myAccount.checkBalance();
            break;
        case 4:
            system("CLS");
            myAccount.displayTransactions();
            break;
        case 5:
            cout << "Exiting";
            for (int i = 0; i < 5; i++)
            {
                cout << ".";
                Sleep(1000);
            }
            system("CLS");
            cout << "\n \t \t Exit sucessfully";

            break;
        default:
            system("CLS");
            cout << "Invalid choice! Please try again." << endl;
        }
    } while (choice != 5);

    return 0;
}
