namespace WpfApp4.Models;

public class Car
{
    public  string Model { get; set; }
    public  string Vendor { get; set; }
    public  int Year { get; set; }

    public Car(string model,string vendor,int year)
    {
        this.Model = model;
        this.Vendor = vendor;
        this.Year = year;
    }

}
