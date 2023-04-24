using System;

class Program
{
    static void Main(string[] args)
    {
        var account = new CurrentAccount("John Smith", 500);

        account.Deposit(1000);

        if (account.Withdraw(1500))
        {
            Console.WriteLine("Withdrawal successful.");
        }
        else
        {
            Console.WriteLine("Withdrawal failed.");
        }

         // Add interest new
        var savingsAccount = new SavingsAccount("Jane Doe", 0.05M);

        savingsAccount.Deposit(5000);

        savingsAccount.AddInterest();

        if (savingsAccount.Withdraw(4000))
        {
            Console.WriteLine("Withdrawal successful.");
        }
        else
        {
            Console.WriteLine("Withdrawal failed.");
        }
    }
}
