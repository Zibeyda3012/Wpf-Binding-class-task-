using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp4.Models;

public class Car:INotifyPropertyChanged
{
    private string model;
    private string vendor;
    private int year;

    public string Model { get => model; set { model = value; OnPropertyChanged(); } }
    public string Vendor { get => vendor; set { vendor = value; OnPropertyChanged(); } }
    public int Year { get => year; set { year = value; OnPropertyChanged(); } }

    public Car()
    { }
    public Car(string model,string vendor,int year)
    {
        this.Model = model;
        this.Vendor = vendor;
        this.Year = year;
    }

    //------------------------------------------------------------------------------------------------------------------

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

}
