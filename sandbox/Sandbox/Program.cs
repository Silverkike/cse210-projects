using System;

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee();
        Console.WriteLine($"Employee Pay: {emp.Calculatepay()}");

        HourlyEmployee hourlyEmp = new HourlyEmployee();
        Console.WriteLine($"Hourly Employee Pay: {hourlyEmp.Calculatepay()}");
    }
}

// Clase padre
public class Employee
{
    public virtual float Calculatepay()
    {
        return 100f;
    }
}

// Clase hija
public class HourlyEmployee : Employee
{
    public override float Calculatepay()
    {
        return 9f * 100f;
    }
}
