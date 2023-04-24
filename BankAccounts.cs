using System;

public class BankAccount
{
    private string customerName;
    private int accountNumber;
    protected decimal balance;


    public BankAccount(string customerName, int accountNumber = 0, decimal balance = 0.00M)
    {
        this.customerName = customerName;
        this.balance = balance;

        if (accountNumber == 0)
        {
            this.accountNumber = 100000 + BankAccountManager.GetNextAccountNumber();
        }
        else
        {
            this.accountNumber = accountNumber;
        }
    }

    public string CustomerName
    {
        get { return customerName; }
        set { customerName = value; }
    }

    public int AccountNumber
    {
        get { return accountNumber; }
    }

    public decimal Balance
    {
        get { return balance; }
    }

    public void Deposit(decimal amount)
    {
        balance += amount;
    }

    public virtual bool Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class CurrentAccount : BankAccount
{
    private decimal overdraftLimit;

    public CurrentAccount(string customerName, decimal overdraftLimit, int accountNumber = 0, decimal balance = 0.00M) 
        : base(customerName, accountNumber, balance)
    {
        this.overdraftLimit = overdraftLimit;
    }

    public override bool Withdraw(decimal amount)
    {
        if (balance + overdraftLimit >= amount)
        {
            balance -= amount;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class SavingsAccount : BankAccount
{
    private decimal interestRate;

    public SavingsAccount(string customerName, decimal interestRate, int accountNumber = 0, decimal balance = 0.00M) 
        : base(customerName, accountNumber, balance)
    {
        this.interestRate = interestRate;
    }

    public void AddInterest()
    {
        balance += balance * interestRate;
    }
}

public static class BankAccountManager
{
    private static int nextAccountNumber = 1;

    public static int GetNextAccountNumber()
    {
        return nextAccountNumber++;
    }
}
