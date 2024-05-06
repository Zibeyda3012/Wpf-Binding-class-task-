using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using WpfApp4.Models;

namespace WpfApp4.Views;

public partial class NewWindow : Window, INotifyPropertyChanged
{
    private Car newCar;
    private string button_text;

    public event PropertyChangedEventHandler PropertyChanged;
    public string Button_Text
    {
        get { return button_text; }
        set 
        {
            button_text = value;
            OnPropertyChanged();
        }
    }


    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public Car NewCar
    {
        get { return newCar; }
        set
        {
            newCar = value;
            OnPropertyChanged();
        }
    }

    public NewWindow()
    {
        InitializeComponent();
        NewCar = new();
        DataContext = this;
    }

    private void Cancel_btn_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
    }

    private void btn_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
    }
}
