using System;

class CuentaBancaria
{
    // Campo privado solo accesible dentro de la clase
    private double saldo;

    // Constructor para inicializar el saldo
    public CuentaBancaria(double saldoInicial)
    {
        saldo = saldoInicial;
    }

    // Método público para depositar dinero
    public void Depositar(double cantidad)
    {
        if (cantidad > 0)
        {
            saldo += cantidad;
            Console.WriteLine($"Depositaste: {cantidad}. Saldo actual: {saldo}");
        }
        else
        {
            Console.WriteLine("La cantidad debe ser positiva.");
        }
    }

    // Método público para retirar dinero
    public void Retirar(double cantidad)
    {
        if (cantidad > 0 && cantidad <= saldo)
        {
            saldo -= cantidad;
            Console.WriteLine($"Retiraste: {cantidad}. Saldo actual: {saldo}");
        }
        else
        {
            Console.WriteLine("Fondos insuficientes o cantidad invalida.");
        }
    }

    // Método público para consultar el saldo
    public double ObtenerSaldo()
    {
        return saldo;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Ejercicio: Cuenta Bancaria");

        CuentaBancaria cuenta = new CuentaBancaria(100); //saldo inicial

        cuenta.Depositar(50); // Depositar 50
        cuenta.Retirar(30);  // Retirar 30
        Console.WriteLine(cuenta.ObtenerSaldo()); // Consultar saldo
    }
}