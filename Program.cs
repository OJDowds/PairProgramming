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
    }
}
