using System;

class BankAccount
{
    private decimal balance;  // Campo privado: solo accesible dentro de la clase

    public BankAccount(decimal initialBalance)
    {
        balance = initialBalance;
    }

    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            balance += amount;
            Console.WriteLine($"Depósito exitoso: +{amount:C}. Nuevo saldo: {balance:C}");
        }
        else
        {
            Console.WriteLine("El monto a depositar debe ser positivo.");
        }
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= balance && amount > 0)
        {
            balance -= amount;
            Console.WriteLine($"Retiro exitoso: -{amount:C}. Nuevo saldo: {balance:C}");
        }
        else
        {
            Console.WriteLine("Fondos insuficientes o monto inválido.");
        }
    }

    public decimal GetBalance()
    {
        return balance;
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount(1000m); // Cuenta con saldo inicial de 1000

        account.Deposit(500m);   // Depositar
        account.Withdraw(200m);  // Retirar
        account.Withdraw(2000m); // Intentar retirar más del saldo

        Console.WriteLine($"Saldo final: {account.GetBalance():C}");

        Console.ReadLine();
    }
}
