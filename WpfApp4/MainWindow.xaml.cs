using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using WpfApp4.Models;
using WpfApp4.Views;

namespace WpfApp4;


public partial class MainWindow : Window, INotifyPropertyChanged
{

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public ObservableCollection<Car> Cars { get; set; }

    private Car myCar;
    public Car MyCar
    {
        get { return myCar; }
        set
        {
            myCar = value;
            OnPropertyChanged();
        }
    }

    public MainWindow()
    {
        InitializeComponent();
        Cars = new ObservableCollection<Car>();
        DataContext = this;
    }

    private void Add_btn_Click(object sender, RoutedEventArgs e)
    {
        NewWindow newWindow = new NewWindow();
        newWindow.Button_Text = "Add";
        newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        Hide();
        newWindow.ShowDialog();
        if (newWindow.DialogResult == true)
            Cars.Add(newWindow.NewCar);
        Show();
    }

    private void ListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        NewWindow newWindow = new NewWindow();
        newWindow.Button_Text = "Update";
        newWindow.NewCar = (sender as ListView).SelectedItem as Car;
        Car tempCar = new(newWindow.NewCar.Model, newWindow.NewCar.Vendor, newWindow.NewCar.Year);
        Hide();
        newWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        newWindow.ShowDialog();
        if(newWindow.DialogResult == true)
        {
            newWindow.NewCar = tempCar;
        }
        Show();
    }
}
