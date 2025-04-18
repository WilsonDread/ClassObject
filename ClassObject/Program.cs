// ClassObject program
using System;

class Contractor
{
    // Get Contractor information from user 
    public string ContractorName { get; set; }
    public int ContractorNumber { get; set; }
    public DateTime StartDate { get; set; }

    public Contractor(string name, int number, DateTime startDate)
    {
        ContractorName = name;
        ContractorNumber = number;
        StartDate = startDate;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Contractor Name: {ContractorName}");
        Console.WriteLine($"Contractor Number: {ContractorNumber}");
        Console.WriteLine($"Start Date: {StartDate.ToShortDateString()}");
    }
}
     // Display all subcontractors and calculate pay
class Subcontractor : Contractor
{
    public int Shift { get; set; } // 1 for Day, 2 for Night
    public double HourlyPayRate { get; set; }

    public Subcontractor(string name, int number, DateTime startDate, int shift, double payRate)
        : base(name, number, startDate)
    {
        Shift = shift;
        HourlyPayRate = payRate;
    }
    // Method to calculate pay with shift differential
    public double ComputePay(double hoursWorked)
    {
        double pay = HourlyPayRate * hoursWorked;
        if (Shift == 2) // Night shift gets a 3% differential
        {
            pay *= 1.03;
        }
        return pay;
    }

    public void DisplaySubcontractorInfo()
    {
        DisplayInfo();
        Console.WriteLine($"Shift: {(Shift == 1 ? "Day" : "Night")}");
        Console.WriteLine($"Hourly Pay Rate: {HourlyPayRate:C}");
    }
}

class Program
{
    // Display all subcontractors and calculate pay
    static void Main()
    {
        Console.Write("Enter contractor name: ");
        string name = Console.ReadLine();

        Console.Write("Enter contractor number: ");
        int number = int.Parse(Console.ReadLine());

        Console.Write("Enter contractor start date (yyyy-mm-dd): ");
        DateTime startDate = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter shift (1 for Day, 2 for Night): ");
        int shift = int.Parse(Console.ReadLine());

        Console.Write("Enter hourly pay rate: ");
        double payRate = double.Parse(Console.ReadLine());

        Subcontractor subcontractor = new Subcontractor(name, number, startDate, shift, payRate);

        Console.Write("Enter hours worked: ");
        double hoursWorked = double.Parse(Console.ReadLine());

        subcontractor.DisplaySubcontractorInfo();
        Console.WriteLine($"Total Pay: {subcontractor.ComputePay(hoursWorked):C}");
    }
}



