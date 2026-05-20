using System;
using System.Collections.Generic;

class BankAccount
{
  
    public string AccountHolder { get; set; }
    public string AccountNumber { get; set; }
    public decimal Balance { get; private set; }

   
    private List<string> transactions = new List<string>();

    public BankAccount(string holder, string number, decimal balance)
    {
        AccountHolder = holder;
        AccountNumber = number;
        Balance = balance;
        
    }

  
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            transactions.Add("Deposited: $" + amount);
            Console.WriteLine("Deposit Successful!");
        }
        else
        {
            Console.WriteLine("Invalid deposit amount!");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Invalid withdrawal amount!");
            return false;
        }

        if (amount <= Balance)
        {
            Balance -= amount;
            transactions.Add("Withdrawn: $" + amount);
            Console.WriteLine("Withdrawal Successful!");
            return true;
        }
        else
        {
            Console.WriteLine("Insufficient Balance!");
            return false;
        }
    }

  
    public void ShowAccountDetails()
    {
        Console.WriteLine("===== ACCOUNT DETAILS =====");
        Console.WriteLine("Account Holder : " + AccountHolder);
        Console.WriteLine("Account Number : " + AccountNumber);
        Console.WriteLine("Balance        : $" + Balance.ToString("F2"));
    }


    public void ShowTransactions()
    {
        Console.WriteLine("===== TRANSACTION HISTORY =====");

        if (transactions.Count == 0)
        {
            Console.WriteLine("No transactions available.");
        }
        else
        {
            foreach (string transaction in transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}

class Program
{
    static void Main()
    {
       
        ShowWelcome();

        Console.Write("Enter Account Holder Name: ");
        string holder  = Console.ReadLine();
        

        Console.Write("Enter Account Number: ");
        string number = Console.ReadLine();

        Console.Write("Enter Opening Balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine());

      
        BankAccount account = new BankAccount(holder, number, balance);

        int choice = 0;

      
        while (choice != 6)
        {
            Console.Clear();
            Console.WriteLine("Welcome :" + holder);
            ShowMenu();

            Console.Write("Choose an option: ");
            choice = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

     
            switch (choice)
            {
                case 1:
                    account.ShowAccountDetails();
                    break;

                case 2:
                    Console.WriteLine("Current Balance: $" + account.Balance.ToString("F2"));
                    break;

                case 3:
                    Console.Write("Enter Deposit Amount: ");
                    decimal depositAmount = Convert.ToDecimal(Console.ReadLine());

                    account.Deposit(depositAmount);
                    break;

                case 4:
                    Console.Write("Enter Withdrawal Amount: ");
                    decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());

                    account.Withdraw(withdrawAmount);
                    break;

                case 5:
                    account.ShowTransactions();
                    break;

                case 6:
                    Console.WriteLine("Thank you for using NDB Bank!");
                    break;

                default:
                    Console.WriteLine("Invalid Menu Option!");
                    break;
            }

    
            if (choice != 6)
            {
                Console.WriteLine();
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }

    static void ShowWelcome()
    {
        Console.WriteLine("=================================");
        Console.WriteLine("         NDB BANK");
        Console.WriteLine("   Welcome to Banking System");
        Console.WriteLine("=================================");
    }


    static void ShowMenu()
    {
        
        Console.WriteLine("========= BANK MENU =========");
        Console.WriteLine("1. View Account");
        Console.WriteLine("2. Check Balance");
        Console.WriteLine("3. Deposit Money");
        Console.WriteLine("4. Withdraw Money");
        Console.WriteLine("5. Transaction History");
        Console.WriteLine("6. Exit");
        Console.WriteLine("=============================");
    }
}



